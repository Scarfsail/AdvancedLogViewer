using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace Scarfsail.Common.BL
{
    public class KeyValueCacheEventArgs<TKey, TValue>
    {
        public KeyValueCacheEventArgs(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        public TKey Key { get; private set; }
        public TValue Value { get; private set; }
    }
    public delegate void KeyValueCacheEventHandler<TKey, TValue>(object sender, KeyValueCacheEventArgs<TKey, TValue> e);

    /// <summary>
    /// Class which cache Value for each Key for specified time period.
    /// After period elapsed, value is automatically deleted from cache.
    /// When new item with same key is added to cache, value and timestamp is updated in the cache
    /// </summary>
    /// <typeparam name="TKey">Type of Key</typeparam>
    /// <typeparam name="TValue">Type of Value to store</typeparam>
    public class KeyValueCache<TKey, TValue>
    {
        private Logging.Log log = new Logging.Log();
        private TimeSpan cacheExpiration;
        private Dictionary<TKey, CacheItem<TValue>> cacheStorage = new Dictionary<TKey, CacheItem<TValue>>();
        private System.Timers.Timer cleanupTimer = new System.Timers.Timer();
        private ReaderWriterLockSlim locker = new ReaderWriterLockSlim();
        private int maxKeyLimit = -1;

        /// <summary>
        /// Creates instance of cache with specified expiration timeout
        /// </summary>
        /// <param name="cacheExpiration">Expiration timeout - when any item isn't accessed for that time, the item is removed from the cache</param>
        public KeyValueCache(TimeSpan cacheExpiration)
        {
            this.cacheExpiration = cacheExpiration;
            this.cleanupTimer.Interval = cacheExpiration.TotalMilliseconds + 1000; //Here is plus one second, when interval elapsed, timestamp has to be older than cacheExpiration
            this.cleanupTimer.Elapsed += new ElapsedEventHandler(CleanupTimer_Elapsed);
            this.cleanupTimer.Enabled = true;
        }

        public KeyValueCache(TimeSpan cacheExpiration, int maxKeyLimit)
            : this(cacheExpiration)
        {
            this.maxKeyLimit = maxKeyLimit;
        }


        /// <summary>
        /// Is raised before any item is removed from the cache (manually or because of expiration)
        /// Warning: event is called in EnterWriteLock section -> blocks any reads from the cache until is finished
        /// </summary>
        public event KeyValueCacheEventHandler<TKey, TValue> BeforeItemRemoved;


        /// <summary>
        /// Try to get Value for specific Key. When not found, returns false and value is null
        /// </summary>
        /// <param name="Key">Key to lookup in the cache</param>
        /// <returns>Instance of cached object for given key</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return this.TryGetValue(key, out value, false);
        }

        /// <summary>
        /// Try to get Value for specific Key. When not found, returns false and value is null
        /// </summary>
        /// <param name="Key">Key to lookup in the cache</param>
        /// <param name="extendItemExpiration">If is true and key is found, expiration for this item in the cache is extended(now+cacheExpiration)</param>
        /// <returns>Instance of cached object for given key</returns>
        public bool TryGetValue(TKey key, out TValue value, bool extendItemExpiration)
        {
            locker.EnterReadLock();
            try
            {
                CacheItem<TValue> item;
                if (this.cacheStorage.TryGetValue(key, out item))
                {
                    log.DebugFormat("Returning value from cache for key: '{0}'", key);
                    if (extendItemExpiration)
                        item.LastAccess = DateTime.Now;
                    value = item.Value;
                    return true;
                }
            }
            finally
            {
                locker.ExitReadLock();
            }
            log.DebugFormat("Key not found in cache: '{0}'", key);
            value = default(TValue);
            return false;
        }

        /// <summary>
        /// Returns count if items in the cache
        /// </summary>
        public int Count
        {
            get
            {
                locker.EnterReadLock();
                try
                {
                    return this.cacheStorage.Count;
                }
                finally
                {
                    locker.ExitReadLock();
                }
            }
        }

        /// <summary>
        /// For given dictionary with keys, performs lookup to cache and sets dictionary value according to cache. If the item is not found,
        /// defult for TValue is used. Returns set of key which were not found, empty set means that for every key value was found.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="extendItemExpiration"></param>
        public ISet<TKey> TryGetValues(IDictionary<TKey, TValue> dictionary, bool extendItemExpiration)
        {
            if (dictionary == null) throw new ArgumentNullException("dictionary");

            HashSet<TKey> notFoundKeys = new HashSet<TKey>();
            int foundKeysCount = 0;
            DateTime now = DateTime.Now;

            locker.EnterReadLock();

            try
            {
                foreach (TKey key in dictionary.Keys.ToArray())
                {
                    CacheItem<TValue> item;
                    if (this.cacheStorage.TryGetValue(key, out item))
                    {
                        if (extendItemExpiration)
                            item.LastAccess = now;
                        dictionary[key] = item.Value;
                        foundKeysCount++;
                    }
                    else
                    {
                        dictionary[key] = default(TValue);
                        notFoundKeys.Add(key);
                    }
                }
            }
            finally
            {
                locker.ExitReadLock();
            }

            log.DebugFormat("Dictionary filled with values, Out of {0} keys, {1} keys were found and {2} keys were not found.", dictionary.Count, foundKeysCount, notFoundKeys.Count);

            return notFoundKeys;
        }

        /// <summary>
        /// Check if given key exists in the cache
        /// </summary>
        /// <param name="key">Key to check if exists in the cache</param>
        /// <returns>True if key exists in the cache, otherwise false</returns>
        public bool ContainsKey(TKey key)
        {
            locker.EnterReadLock();
            try
            {
                return cacheStorage.ContainsKey(key);
            }
            finally
            {
                locker.ExitReadLock();
            }
        }
        /// <summary>
        /// Check if cache contains any value specified by the predicate
        /// </summary>
        /// <param name="predicate">Predicate which is used to match cache item in the cache</param>
        /// <returns>True if cache contains item specified by the predicate</returns>
        public bool AnyValue(Func<TValue, bool> predicate)
        {
            locker.EnterReadLock();
            try
            {
                foreach (CacheItem<TValue> item in this.cacheStorage.Values)
                {
                    if (predicate(item.Value))
                        return true;
                }
            }
            finally
            {
                locker.ExitReadLock();
            }
            return false;

        }

        /// <summary>
        /// Clear all the content from this cache
        /// </summary>
        public void Clear()
        {
            locker.EnterUpgradeableReadLock();
            try
            {
                log.Debug("Cleaning cache storage ....");
                TKey[] keysToDelete = this.cacheStorage.Keys.ToArray();
                foreach (TKey key in keysToDelete)
                {
                    Remove(key);
                }
                log.Debug("Cache storage cleaned.");
            }
            finally
            {
                locker.ExitUpgradeableReadLock();
            }
        }

        /// <summary>
        /// Store Value for given Key
        /// In case Key already exists, Value is replaced and TimeStamp is updated
        /// </summary>
        /// <param name="key">Key for the Value</param>
        /// <param name="filters">Instance of Value to store</param>
        public void StoreValue(TKey key, TValue value)
        {
            StoreValue(key, value, true);
        }

        /// <summary>
        /// Store Value for given Key
        /// In case Key already exists and replaceValue is true, Value is replaced and TimeStamp is updated. If replace value is false, just TimeStamp is updated.
        /// </summary>
        /// <param name="key">Key for the Value</param>
        /// <param name="filters">Instance of Value to store</param>
        /// <param name="replaceValue">If true and key exists, value is replaced</param>
        public void StoreValue(TKey key, TValue value, bool replaceValue)
        {
            locker.EnterWriteLock();
            try
            {
                CacheItem<TValue> item = null;
                if (this.cacheStorage.TryGetValue(key, out item))
                {
                    log.DebugFormat("Key is already in the cache, LastAccess updated and Value {0}. Key: '{1}' ", replaceValue ? "also updated" : "not updated", key);
                    if (replaceValue)
                        item.Value = value;
                    item.LastAccess = DateTime.Now;
                }
                else
                {
                    log.DebugFormat("Storing value to cache. Key: '{0}'", key);
                    item = new CacheItem<TValue>(value);
                    this.cacheStorage[key] = item;
                }
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }

        /// <summary>
        /// Stores values in given dictionary to cache.
        /// In case Key already exists and replaceValue is true, Value is replaced and TimeStamp is updated. If replace value is false, just TimeStamp is updated.
        /// </summary>
        /// <param name="valuePairs"></param>
        /// <param name="replaceValues"></param>
        public void StoreValues(IDictionary<TKey, TValue> valuePairs, bool replaceValues)
        {
            if (valuePairs == null) throw new ArgumentNullException("valuePairs");
            if (valuePairs.Count == 0) return;

            locker.EnterWriteLock();

            try
            {
                DateTime now = DateTime.Now;
                int newValuesStored = 0;

                foreach (KeyValuePair<TKey, TValue> keyValuePair in valuePairs)
                {
                    CacheItem<TValue> item;
                    if (this.cacheStorage.TryGetValue(keyValuePair.Key, out item))
                    {
                        if (replaceValues)
                            item.Value = keyValuePair.Value;
                        item.LastAccess = now;
                    }
                    else
                    {
                        item = new CacheItem<TValue>(keyValuePair.Value);
                        this.cacheStorage[keyValuePair.Key] = item;
                        newValuesStored++;
                    }
                }

                log.DebugFormat("Out of {0} values, stored {1} new items.", valuePairs.Count, newValuesStored);
            }
            finally
            {
                locker.ExitWriteLock();
            }

        }

        /// <summary>
        /// Removes item specified by the key from the cache
        /// Before item is removed, BeforeItemRemoved event is raised
        /// </summary>
        /// <param name="key">Key of item to remove</param>
        /// <returns>True if item has been removed succesfully. False if item isn't in cache and thus can't be removed.</returns>
        public bool Remove(TKey key)
        {
            log.DebugFormat("Removing value from cache. Key: '{0}'", key);
            locker.EnterWriteLock();
            try
            {
                if (this.BeforeItemRemoved != null)
                    this.BeforeItemRemoved(this, new KeyValueCacheEventArgs<TKey, TValue>(key, cacheStorage[key].Value));

                return cacheStorage.Remove(key);
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }

        private void CleanupTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            locker.EnterUpgradeableReadLock();
            try
            {
                TKey[] keysToDelete = this.cacheStorage.Where(f => f.Value.LastAccess.AddMilliseconds(this.cacheExpiration.TotalMilliseconds) < DateTime.Now).Select(i => i.Key).ToArray();
                foreach (var key in keysToDelete)
                {
                    this.Remove(key);
                }
                //log.DebugFormat("Cache expiration cleanup performed, items in the cache: {0}. Items cleaned: {1}", this.cacheStorage.Count, keysToDelete.Length);

                if (maxKeyLimit > 0 && cacheStorage.Count > maxKeyLimit)
                {
                    log.DebugFormat("Cache size exceeds maximum limit of {0} items", maxKeyLimit);

                    var itemsToRemoveCount = cacheStorage.Count - maxKeyLimit;
                    keysToDelete = cacheStorage.OrderBy(f => f.Value.LastAccess).Take(itemsToRemoveCount).Select(i => i.Key).ToArray();
                    foreach (var key in keysToDelete)
                    {
                        Remove(key);
                    }

                    log.DebugFormat("Cache key limit cleanup performed, items in the cache: {0}. Items removed: {1}", cacheStorage.Count, keysToDelete.Length);
                }
            }
            finally
            {
                locker.ExitUpgradeableReadLock();
            }
        }


        private class CacheItem<TCacheValue>
        {
            public CacheItem(TCacheValue value)
            {
                this.Value = value;
                this.LastAccess = DateTime.Now;
            }

            public TCacheValue Value { get; set; }
            public DateTime LastAccess { get; set; }
        }
    }
}

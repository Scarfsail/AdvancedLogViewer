using System;
using System.Dynamic;
using System.Collections.Generic;

namespace SqlLinq
{
    class GroupByCall<TSource, TResult>
    {
        private IDictionary<string, Delegate> m_aggregates = new Dictionary<string, Delegate>();

        public GroupByCall(string keyName)
        {
            KeyName = keyName;
        }

        public IDictionary<string, Delegate> Aggregates
        {
            get
            {
                return m_aggregates;
            }
        }

        public string KeyName { get; private set; }

        public TResult GroupingFunc<TKey>(TKey key, IEnumerable<TSource> source)
        {
            if (typeof(TResult) == typeof(object))
                return Expando<TKey>(key, source);

            if(typeof(TResult).HasEmptyConstructor())
                return MemberInit<TKey>(key, source);

            return ConstructorCall<TKey>(key, source);
        }

        private TResult Expando<TKey>(TKey key, IEnumerable<TSource> source)
        {
            IDictionary<string, object> expando = (IDictionary<string, object>)new ExpandoObject();
            expando.Add(KeyName, key);

            foreach (KeyValuePair<string, Delegate> pair in m_aggregates)
                expando.Add(pair.Key, pair.Value.DynamicInvoke(source));

            return (TResult)(object)expando;
        }

        private TResult ConstructorCall<TKey>(TKey key, IEnumerable<TSource> source)
        {
            List<object> list = new List<object>();
            list.Add(key);

            foreach (KeyValuePair<string, Delegate> pair in m_aggregates)
                list.Add(pair.Value.DynamicInvoke(source));

            return (TResult)Activator.CreateInstance(typeof(TResult), list.ToArray());
        }

        private TResult MemberInit<TKey>(TKey key, IEnumerable<TSource> source)
        {
            TResult result = Activator.CreateInstance<TResult>();
            typeof(TResult).GetProperty(KeyName).SetValue(result, key, null);

            foreach (KeyValuePair<string, Delegate> pair in m_aggregates)
            {
                object o = pair.Value.DynamicInvoke(source);
                typeof(TResult).GetProperty(pair.Key).SetValue(result, o, null);
            }

            return result;
        }
    }
}

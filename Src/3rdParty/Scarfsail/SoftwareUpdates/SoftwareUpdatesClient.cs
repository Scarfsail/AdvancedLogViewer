using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using Scarfsail.Common.BL;

namespace Scarfsail.SoftwareUpdates
{
    public class SoftwareUpdatesClient
    {
        private SoftwareUpdatesClientSettings settings;


        public SoftwareUpdatesClient(SoftwareUpdatesClientSettings settings)
        {
            this.settings = settings;
        }


        public void CheckForUpdate(bool skipIfPeriodNotElapsed, bool fireErrorEvent, bool fireNotFoundEvent)
        {
            WaitCallback callback = new WaitCallback((object state) => DoCheckForUpdate(skipIfPeriodNotElapsed, fireErrorEvent, fireNotFoundEvent));
            ThreadPool.QueueUserWorkItem(callback, null);
        }

        private void DoCheckForUpdate(bool skipIfPeriodNotElapsed, bool fireErrorEvent, bool fireNotFoundEvent)
        {
            OnUpdateCheckStarted();
            UpdatesHistoryInfo updatesHistoryInfo = UpdatesHistoryInfo.LoadFromFile(Path.Combine(this.settings.ProductPathToStoreHistoryInfo, "SoftwareUpdateHistory.xml"), XmlSerializableFileCorruptedAction.LoadDefaultsSilently);
            try
            {
                if (skipIfPeriodNotElapsed && (updatesHistoryInfo.LastUpdateCheck + settings.UpdateCheckPeriod > DateTime.Now))
                    return;

                updatesHistoryInfo.LastUpdateCheck = DateTime.Now;

                string tmpPath = Path.Combine(Path.Combine(Path.GetTempPath(), "Scarfsail.SoftwareUpdates"), Guid.NewGuid().ToString());
                if (!Directory.Exists(tmpPath))
                    Directory.CreateDirectory(tmpPath);

                //Download definition xml file
                string definitionXmlFileName = Path.Combine(tmpPath, "Definition.xml");
                if (File.Exists(definitionXmlFileName))
                    File.Delete(definitionXmlFileName);

                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(settings.RemoteDefinitionXmlUrl + String.Format("?Version={0}&ForceCheck={1}", settings.ProductVersion, !skipIfPeriodNotElapsed), definitionXmlFileName);
                }

                UpdateDefinitionXml updateDefinitionXml = UpdateDefinitionXml.LoadFromFile(definitionXmlFileName, XmlSerializableFileCorruptedAction.LoadDefaultsSilently);

                if (updateDefinitionXml.LatestVersion.Version > settings.ProductVersion)
                {
                    updatesHistoryInfo.LastUpdateFound = DateTime.Now;
                    OnUpdateFound(new UpdateFoundEventArgs(updateDefinitionXml, settings.ProductVersion, tmpPath));
                }
                else
                {
                    if (fireNotFoundEvent)
                        this.OnUpdateNotFound(skipIfPeriodNotElapsed);
                }

            }
            catch (WebException ex)
            {
                UpdateErrorHandler(ex.InnerException != null ? ex.InnerException.Message : ex.Message, updatesHistoryInfo, fireErrorEvent, skipIfPeriodNotElapsed);
            }
            catch (Exception ex)
            {
                UpdateErrorHandler(ex.Message, updatesHistoryInfo, fireErrorEvent, skipIfPeriodNotElapsed);
            }
            finally
            {
                updatesHistoryInfo.Save();
                OnUpdateCheckFinished();
            }
        }


        public event EventHandler<UpdateFoundEventArgs> UpdateFound;
        public event EventHandler<UpdateEventArgs> UpdateError;
        public event EventHandler<UpdateEventArgs> UpdateNotFound;
        public event EventHandler UpdateCheckStarted;
        public event EventHandler UpdateCheckFinished;

        private void UpdateErrorHandler(string message, UpdatesHistoryInfo updatesHistoryInfo, bool fireErrorEvent, bool skipIfPeriodNotElapsed)
        {
            updatesHistoryInfo.LastUpdateError = DateTime.Now;
            if (fireErrorEvent)
                OnUpdateError(new UpdateEventArgs(message, skipIfPeriodNotElapsed));
        }

        protected void OnUpdateFound(UpdateFoundEventArgs e)
        {
            if (this.UpdateFound != null)
                this.UpdateFound(this, e);
        }

        protected void OnUpdateError(UpdateEventArgs e)
        {
            if (this.UpdateError != null)
                this.UpdateError(this, e);
        }
        protected void OnUpdateNotFound(bool skipIfPeriodNotElapsed)
        {
            if (this.UpdateNotFound != null)
                this.UpdateNotFound(this, new UpdateEventArgs("", skipIfPeriodNotElapsed));
        }
        
        protected void OnUpdateCheckStarted()
        {
            if (this.UpdateCheckStarted != null)
                this.UpdateCheckStarted(this, new EventArgs());
        }

        protected void OnUpdateCheckFinished()
        {
            if (this.UpdateCheckFinished != null)
                this.UpdateCheckFinished(this, new EventArgs());
        }
    }
}

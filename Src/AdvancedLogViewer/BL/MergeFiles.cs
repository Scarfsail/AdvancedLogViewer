using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace AdvancedLogViewer.BL
{
    public class MergeProgressEventArgs : EventArgs
    {
        public MergeProgressEventArgs(int percentComplete, string currentFileName)
        {
            this.PercentComplete = percentComplete;
            this.CurrentFileName = currentFileName;
        }

        public int PercentComplete { get; private set; }
        public string CurrentFileName { get; private set; }
    }

    public class MergeCompleteEventArgs : EventArgs
    {
        public MergeCompleteEventArgs(bool successfuly)
        {
            this.Successfuly = successfuly;
        }

        public bool Successfuly { get; private set; }
    }

    public delegate void MergeProgressEventHandler(object sender, MergeProgressEventArgs e);
    public delegate void MergeCompleteEventHandler(object sender, MergeCompleteEventArgs e);
    
    public class MergeFiles
    {
        public MergeFiles(List<string> fileNames, string mergedFileName)
        {
            this.fileNames = fileNames;
            this.mergedFileName = mergedFileName;
        }

        public void MergeAsync()
        {
            Thread mergeThread = new Thread(new ThreadStart(this.Merge));
            mergeThread.Start();
        }

        public void Cancel()
        {
            this.cancel = true;
        }

        public event MergeProgressEventHandler MergeProgress;
        public event MergeCompleteEventHandler MergeComplete;
        
        protected void OnProgress(int percentComplete, string currentFileName)
        {
            if (this.MergeProgress != null)
                this.MergeProgress(this, new MergeProgressEventArgs(percentComplete, currentFileName));
        }
        
        protected void OnComplete(bool successfuly)
        {
            if (this.MergeComplete != null)
                this.MergeComplete(this, new MergeCompleteEventArgs(successfuly));
        }

        private void Merge()
        {
            if (File.Exists(mergedFileName))
                File.Delete(mergedFileName);
            
            this.cancel = false;

            using (FileStream fileOut = new FileStream(mergedFileName, FileMode.CreateNew))
            {
                for (int i = 0; i < this.fileNames.Count; i++)
                {
                    string srcFileName = this.fileNames[i];
                    OnProgress(100 / this.fileNames.Count * i, srcFileName);

                    using (FileStream fileIn = new FileStream(srcFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        int buffSize = 1048576; //1 MB
                        byte[] buff = new byte[buffSize];
                        int readed;
                        fileIn.Seek(0, SeekOrigin.Begin);
                        while ((readed = fileIn.Read(buff, 0, buffSize)) > 0)
                        {
                            fileOut.Write(buff, 0, readed);
                            if (cancel)
                                break;
                        }
                    }
                    if (cancel)
                        break;
                }
            }
            OnComplete(!cancel);
        }
        
        private List<string> fileNames;
        private string mergedFileName;
        private bool cancel;
    }
}

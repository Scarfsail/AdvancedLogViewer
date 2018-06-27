using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Scarfsail.Common.BL;
using System.Xml.Linq;

namespace AdvancedLogViewer.BL.Settings
{
    public class RecentFiles : XmlSerializable<RecentFiles>
    {
        public void AddFile(string fileName)
        {
            this.AddFileInternal(fileName, null);
        }

        public void AddFile(string fileName, bool favorite)
        {
            this.AddFileInternal(fileName, favorite);
        }

        private void AddFileInternal(string fileName, bool? favorite)
        {
            string existingFile = this.FileList.FirstOrDefault(f => f.Equals(fileName, StringComparison.OrdinalIgnoreCase));
            if (existingFile != null)
            {
                this.FileList.Remove(existingFile);
                if (favorite == null)
                    favorite = false;
            }
            else
            {
                existingFile = this.FileListFavorites.FirstOrDefault(f => f.Equals(fileName, StringComparison.OrdinalIgnoreCase));
                if (existingFile != null)
                {
                    this.FileListFavorites.Remove(existingFile);
                    if (favorite == null)
                        favorite = true;
                }
            }

            if (favorite == null)
                favorite = false;

            if (favorite.Value)
            {
                this.FileListFavorites.Insert(0, fileName);
            }
            else
            {
                this.FileList.Insert(0, fileName);
                if (this.FileList.Count > maxNumberOfFiles)
                {
                    this.FileList.RemoveAt(this.FileList.Count - 1);
                }
            }
        }

        public void RemoveNonExistingFiles()
        {
            this.RemoveNonExistingFiles(this.FileList);
            this.RemoveNonExistingFiles(this.FileListFavorites);            
        }

        public void ReplaceFileNamesByBaseNames(Func<string, string> getBaseName)
        {
            this.ReplaceFileNamesByBaseNames(getBaseName, false);
            this.ReplaceFileNamesByBaseNames(getBaseName, true);
        }
        
        private void ReplaceFileNamesByBaseNames(Func<string, string> getBaseName, bool favorites)           
        {
            List<string> fileList = favorites ? this.FileListFavorites : this.FileList;

            for (int i = fileList.Count - 1; i >= 0; i--)
            {
                string fileName = fileList[i];
                string baseFileName = getBaseName(fileName);
                if (fileName != baseFileName)
                {
                    fileList.RemoveAt(i);
                    this.AddFile(baseFileName, favorites);
                    i++;
                }
            }

        }

        private void RemoveNonExistingFiles(List<string> fileList)
        {
            for (int i = fileList.Count - 1; i >= 0; i--)
            {
                string fileName = fileList[i];
                if (!File.Exists(fileName))
                {
                    fileList.RemoveAt(i);
                }
            }
        }

        public List<string> FileList { get; private set; }
        public List<string> FileListFavorites { get; private set; }


        protected override void LoadData(XElement xmlElement)
        {
            this.FileList = GetList<string>(element => element.Value, xmlElement, "FileList");
            this.FileListFavorites = GetList<string>(element => element.Value, xmlElement, "FileListFavorites");
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddList<string>(item => new XElement("FileName", item), xmlElement, "FileList", this.FileList);
            AddList<string>(item => new XElement("FileName", item), xmlElement, "FileListFavorites", this.FileListFavorites);
        }

        private const int maxNumberOfFiles = 20;
    }
}

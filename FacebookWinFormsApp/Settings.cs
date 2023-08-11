﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;

namespace BasicFacebookFeatures
{
    public class Settings
    {
        private static Settings s_Instance = null;
        private static readonly object sr_InstanceLockContext = new object();
        public Size LastWindowSize { get; set; }
        public string UserAccessToken { get; set; }
        public bool RememberUser { get; set; }

        private Settings()
        {
            // Default settings
            LastWindowSize = new Size(1265, 753);
            RememberUser = false;
            UserAccessToken = "";
        }

        public static Settings Instance
        {
            get
            {
                if(s_Instance == null)
                {
                    lock(sr_InstanceLockContext)
                    {
                        if(s_Instance == null)
                        {
                            s_Instance = new Settings();
                            s_Instance = LoadSettingsFromFile();
                        }
                    }
                }

                return s_Instance;
            }
        }

        public void SaveSettingsToFile()
        {
            using (Stream stream = new FileStream($"{GetSolutionRoot()}\\FacebookWinFormsApp\\settings.xml", FileMode.Truncate))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());

                serializer.Serialize(stream, this);
            }
        }

        private static Settings LoadSettingsFromFile()
        {
            Settings settings = null;

            try
            {
                using (Stream stream = new FileStream($"{GetSolutionRoot()}\\FacebookWinFormsApp\\settings.xml", FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));

                    settings = serializer.Deserialize(stream) as Settings;
                }
            }
            catch(Exception ex)
            {
                settings = new Settings();
                throw ex;
            }

            return settings;
        }

        static string GetSolutionRoot()
        {
            string rootPath = string.Empty;
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);

            while (directoryInfo != null)
            {
                FileInfo[] solutionFiles = directoryInfo.GetFiles("*.sln");
                if (solutionFiles.Length > 0)
                {
                    rootPath = directoryInfo.FullName;
                }

                directoryInfo = directoryInfo.Parent;
            }

            return rootPath;
        }
    }
}
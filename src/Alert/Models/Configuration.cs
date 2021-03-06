﻿using System;
using System.IO;
using System.Reflection;

namespace cAlgo.API.Alert.Models
{
    public class Configuration
    {
        public Configuration()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Version version = Assembly.GetExecutingAssembly().GetName().Version;

            string alertsDirPath = Path.Combine(documentsPath, "cAlgo", "Alerts", version.ToString());

            if (!Directory.Exists(alertsDirPath))
            {
                Directory.CreateDirectory(alertsDirPath);
            }

            AlertsFilePath = Path.Combine(alertsDirPath, $"data.db");
            SettingsFilePath = Path.Combine(alertsDirPath, $"settings.xml");
            LogFilePath = Path.Combine(alertsDirPath, $"logs.log");

            Title = $"Alerts - cTrader";
        }

        #region Properties

        public string AlertsFilePath { get; set; }

        public string SettingsFilePath { get; set; }

        public string LogFilePath { get; set; }

        public string Title { get; set; }

        public static Configuration Current { get; set; } = new Configuration();

        #endregion Properties
    }
}
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace BPMNET.Configuration
{
    public sealed class Config
    {
        private const string SECTION_NAME = "bpmNet";
        private static readonly object padlock = new object();
        private static Config instance = null;
        private readonly ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
        private readonly Section BpmSection = (Section)ConfigurationManager.GetSection(SECTION_NAME);

        public static DatabaseGeneratedOption DefaultDatabaseGeneratedOption = DatabaseGeneratedOption.None;
        public static bool DefaultUnicodeString = true;

        private Config() { }
        public static Config Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Config();
                        }
                    }
                }
                return instance;
            }
        }

        public string ConnectionName
        {
            get
            {
                if (BpmSection != null && !string.IsNullOrWhiteSpace(BpmSection.ConnectionName)) return BpmSection.ConnectionName;
                if (connectionStrings["DefaultConnection"] != null) return connectionStrings["DefaultConnection"].ToString();
                if (connectionStrings.Count > 0)
                {
                    return connectionStrings[0] != null ? connectionStrings["DefaultConnection"].ToString() : null;
                }
                return null;
            }
        }

        public DatabaseGeneratedOption GeneratedOption
        {
            get
            {
                if (BpmSection == null) return DefaultDatabaseGeneratedOption;
                switch (BpmSection.GeneratedOption.ToLower())
                {
                    case "none": return DatabaseGeneratedOption.None;
                    case "identity": return DatabaseGeneratedOption.Identity;
                    case "computed": return DatabaseGeneratedOption.Computed;
                    default: return DefaultDatabaseGeneratedOption;
                }
            }
        }

        public bool UnicodeString
        {
            get
            {
                if (BpmSection == null) return DefaultUnicodeString;
                return BpmSection.UnicodeString;
            }
        }

        public TableConfigElement Tables
        {
            get
            {
                if (BpmSection == null || BpmSection.Tables == null) return new TableConfigElement();
                return BpmSection.Tables;
            }
        }
    }
}

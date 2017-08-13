using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace BPMNET.Configuration
{
    internal sealed class Config
    {
        private const string SECTION_NAME = "BpmNet";
        private static readonly object padlock = new object();
        private static Config instance = null;
        private readonly ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
        private readonly Section BpmSection = (Section)ConfigurationManager.GetSection(SECTION_NAME);

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

        internal string ConnectionName
        {
            get
            {
                string dconnName = connectionStrings["DefaultConnection"] != null ? connectionStrings["DefaultConnection"].ToString() : null;
                if (BpmSection == null) return dconnName;
                return BpmSection.ConnectionName;
            }
        }

        internal DatabaseGeneratedOption GeneratedOption
        {
            get
            {
                DatabaseGeneratedOption value = DatabaseGeneratedOption.None;
                if (BpmSection == null) return value;
                Enum.TryParse(BpmSection.GeneratedOption, out value);
                return value;
            }
        }
        //internal string KeyType
        //{
        //    get
        //    {
        //        if (BpmSection == null) return "string";
        //        return BpmSection.KeyType;
        //    }
        //}

        public bool UnicodeString
        {
            get
            {
                if (BpmSection == null) return false;
                return BpmSection.UnicodeString;
            }
        }
    }
}

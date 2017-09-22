using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace BPMNET.Configuration
{
    [ExcludeFromCodeCoverage]
    internal sealed class Section : ConfigurationSection
    {
        private const string CONNECTION_NAME = "ConnectionName";
        private const string CONNECTION = "DefaultConnection";
        private const string KEY_TYPE_NAME = "KeyType";
        private const string KEY_TYPE = "string";
        private const string GENERATED_KEY_NAME = "GeneratedOption";
        private const string GENERATED_KEY = "Default";
        private const string UNICODE_NAME = "UnicodeString";
        private const bool UNICODE = false;

        public Section() { }

        [ConfigurationProperty(CONNECTION_NAME, IsKey = false, IsRequired = false, DefaultValue = CONNECTION)]
        public string ConnectionName
        {
            get
            {
                return (this[CONNECTION_NAME] != null ? this[CONNECTION_NAME].ToString() : CONNECTION);
            }
        }

        [ConfigurationProperty(KEY_TYPE_NAME, IsKey = false, DefaultValue = KEY_TYPE)]
        public string KeyType
        {
            get
            {
                return (this[KEY_TYPE_NAME] != null ? this[KEY_TYPE_NAME].ToString() : KEY_TYPE);
            }
        }

        [ConfigurationProperty(GENERATED_KEY_NAME, IsKey = false, DefaultValue = GENERATED_KEY)]
        public string GeneratedOption
        {
            get
            {
                return (this[GENERATED_KEY_NAME] != null ? this[GENERATED_KEY_NAME].ToString() : GENERATED_KEY);
            }
        }

        [ConfigurationProperty(UNICODE_NAME, IsKey = false, DefaultValue = UNICODE)]
        public bool UnicodeString
        {
            get
            {
                return (this[UNICODE_NAME] != null ? bool.Parse(this[UNICODE_NAME].ToString()) : UNICODE);
            }
        }

        [ConfigurationProperty("Tables")]
        public TableConfigElement Tables
        {
            get
            { return (TableConfigElement)this["Tables"]; }
        }
    }
}

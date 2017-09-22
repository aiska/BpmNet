using System.Configuration;

namespace BPMNET.Configuration
{
    public sealed class TableConfigElement : ConfigurationElement
    {
        private const string INVALID_CHARACTER = "~!@#$%^&*(){}/;'\"|\\";
        private const string DEPLOYMENT = "Deployment";
        private const string DEFINITION = "Definition";
        private const string DEFINITION_ITEM = "DefinitionItem";
        private const string PROCESS_INSTANCE = "ProcessInstance";
        private const string PROCESS_TASK = "ProcessTask";
        private const string BPMN_PROCESS = "BpmnProcess";
        private const string PROCESS_VARIABLES = "ProcessVariables";
        private const string DEFINITION_VARIABLES = "DefinitionVariable";
        private const string COMMENT = "Comment";
        private const string SEQUENCE_FLOW = "SequenceFlow";
        private const string DATA_OBJECT = "DataObject";
        private const string FLOW_NODE = "FlowNode";
        private const string APPROVAL = "Approval";
        private const string ACTIVITY = "Activity";
        private const string PROCESS_FLOW = "ProcessFlow";

        private const string DEPLOYMENT_TABLE = "AP_DEPLOYMENT";
        private const string DEFINITION_TABLE = "AP_DEFINITION";
        private const string DEFINITION_ITEM_TABLE = "AP_DEFINITION_ITEM";
        private const string DEFINITION_VARIABLES_TABLE = "AP_DEFINITION_VARIABLE";
        private const string DEFAULT_PROCESS_INSTANCE_TABLE = "AP_PROCESS_INSTANCE";
        private const string DEFAULT_PROCESS_TASK_TABLE = "AP_PROCESS_TASK";
        private const string COMMENT_TABLE = "AP_COMMENT";
        private const string DEFINITION_VARIABLE = "AP_DEFINITION_VARIABLE";
        private const string PROCESS_TABLE = "AP_PROCESS";
        private const string PROCESS_VARIABLES_TABLE = "AP_VARIABLES";
        private const string SEQUENCE_FLOW_TABLE = "AP_SEQUENCE_FLOW";
        private const string DATA_OBJECT_TABLE = "AP_DATA_OBJECT";
        private const string FLOW_NODE_TABLE = "AP_FLOW_NODE";
        private const string APPROVAL_TABLE = "AP_APPROVAL";
        private const string ACTIVITY_TABLE = "AP_ACTIVITY";
        private const string PROCESS_FLOW_TABLE = "AP_PROCESS_FLOW";


        public TableConfigElement()
        {
        }

        [ConfigurationProperty(DEPLOYMENT, DefaultValue = DEPLOYMENT_TABLE, IsRequired = false)]
        [StringValidator(InvalidCharacters = INVALID_CHARACTER, MinLength = 1, MaxLength = 60)]
        public string Deployment
        {
            get
            { return (string)this[DEPLOYMENT]; }
            //set
            //{ this[DEPLOYMENT] = value; }
        }

        [ConfigurationProperty(DEFINITION, DefaultValue = DEFINITION_TABLE, IsRequired = false)]
        [StringValidator(InvalidCharacters = INVALID_CHARACTER, MinLength = 1, MaxLength = 60)]
        public string Definition
        {
            get
            { return (string)this[DEFINITION]; }
            //set
            //{ this[DEFINITION] = value; }
        }

        [ConfigurationProperty(DEFINITION_ITEM, DefaultValue = DEFINITION_ITEM_TABLE, IsRequired = false)]
        [StringValidator(InvalidCharacters = INVALID_CHARACTER, MinLength = 1, MaxLength = 60)]
        public string DefinitionItem
        {
            get
            { return (string)this[DEFINITION_ITEM]; }
            //set
            //{ this[DEFINITION_ITEM] = value; }
        }

        [ConfigurationProperty(PROCESS_INSTANCE, DefaultValue = DEFAULT_PROCESS_INSTANCE_TABLE, IsRequired = false)]
        [StringValidator(InvalidCharacters = INVALID_CHARACTER, MinLength = 1, MaxLength = 60)]
        public string ProcessInstance
        {
            get
            { return (string)this[PROCESS_INSTANCE]; }
            //set
            //{ this[PROCESS_INSTANCE] = value; }
        }

        [ConfigurationProperty(PROCESS_TASK, DefaultValue = DEFAULT_PROCESS_TASK_TABLE, IsRequired = false)]
        [StringValidator(InvalidCharacters = INVALID_CHARACTER, MinLength = 1, MaxLength = 60)]
        public string ProcessTask
        {
            get
            { return (string)this[PROCESS_TASK]; }
            //set
            //{ this[PROCESS_TASK] = value; }
        }

        [ConfigurationProperty(BPMN_PROCESS, DefaultValue = PROCESS_TABLE, IsRequired = false)]
        [StringValidator(InvalidCharacters = INVALID_CHARACTER, MinLength = 1, MaxLength = 60)]
        public string BpmnProcess
        {
            get
            { return (string)this[BPMN_PROCESS]; }
            //set
            //{ this[BPMN_PROCESS] = value; }
        }

        [ConfigurationProperty(PROCESS_VARIABLES, DefaultValue = PROCESS_VARIABLES_TABLE, IsRequired = false)]
        [StringValidator(InvalidCharacters = INVALID_CHARACTER, MinLength = 1, MaxLength = 60)]
        public string ProcessVariables
        {
            get
            { return (string)this[PROCESS_VARIABLES]; }
            //set
            //{ this[PROCESS_VARIABLES] = value; }
        }

        //[ConfigurationProperty(DEFINITION_VARIABLES, DefaultValue = DEFINITION_VARIABLES_TABLE, IsRequired = false)]
        //[StringValidator(InvalidCharacters = INVALID_CHARACTER, MinLength = 1, MaxLength = 60)]
        //public string DefinitionVariable
        //{
        //    get
        //    { return (string)this[DEFINITION_VARIABLES]; }
        //    set
        //    { this[DEFINITION_VARIABLES] = value; }
        //}

        [ConfigurationProperty(COMMENT, DefaultValue = COMMENT_TABLE, IsRequired = false)]
        [StringValidator(InvalidCharacters = INVALID_CHARACTER, MinLength = 1, MaxLength = 60)]
        public string Comment
        {
            get
            { return (string)this[COMMENT]; }
            //set
            //{ this[COMMENT] = value; }
        }

        [ConfigurationProperty(SEQUENCE_FLOW, DefaultValue = SEQUENCE_FLOW_TABLE, IsRequired = false)]
        [StringValidator(InvalidCharacters = INVALID_CHARACTER, MinLength = 1, MaxLength = 60)]
        public string SequenceFlow
        {
            get
            { return (string)this[SEQUENCE_FLOW]; }
            //set
            //{ this[SEQUENCE_FLOW] = value; }
        }

        //[ConfigurationProperty(DATA_OBJECT, DefaultValue = DATA_OBJECT_TABLE, IsRequired = false)]
        //[StringValidator(InvalidCharacters = INVALID_CHARACTER, MinLength = 1, MaxLength = 60)]
        //public string DataObject
        //{
        //    get
        //    { return (string)this[DATA_OBJECT]; }
        //    set
        //    { this[DATA_OBJECT] = value; }
        //}
        [ConfigurationProperty(FLOW_NODE, DefaultValue = FLOW_NODE_TABLE, IsRequired = false)]
        [StringValidator(InvalidCharacters = INVALID_CHARACTER, MinLength = 1, MaxLength = 60)]
        public string FlowNode
        {
            get
            { return (string)this[FLOW_NODE]; }
            //set
            //{ this[FLOW_NODE] = value; }
        }

        //[ConfigurationProperty(APPROVAL, DefaultValue = APPROVAL_TABLE, IsRequired = false)]
        //[StringValidator(InvalidCharacters = INVALID_CHARACTER, MinLength = 1, MaxLength = 60)]
        //public string Approval
        //{
        //    get
        //    { return (string)this[APPROVAL]; }
        //    set
        //    { this[APPROVAL] = value; }
        //}

        //[ConfigurationProperty(ACTIVITY, DefaultValue = ACTIVITY_TABLE, IsRequired = false)]
        //[StringValidator(InvalidCharacters = INVALID_CHARACTER, MinLength = 1, MaxLength = 60)]
        //public string Activity
        //{
        //    get
        //    { return (string)this[ACTIVITY]; }
        //    set
        //    { this[ACTIVITY] = value; }
        //}

        [ConfigurationProperty(PROCESS_FLOW, DefaultValue = PROCESS_FLOW_TABLE, IsRequired = false)]
        [StringValidator(InvalidCharacters = INVALID_CHARACTER, MinLength = 1, MaxLength = 60)]
        public string ProcessFlow
        {
            get
            { return (string)this[PROCESS_FLOW]; }
            //set
            //{ this[PROCESS_FLOW] = value; }
        }
        
    }
}

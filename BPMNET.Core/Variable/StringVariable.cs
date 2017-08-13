namespace BPMNET.Core.Variable
{
    public class StringVariable : AbstractVariable
    {
        public override EStoreType StoreType
        {
            get { return EStoreType.StringValue; }
        }

        public override bool CheckForStore(object value)
        {
            if (value == null) return false;
            Value = value.ToString();
            return true;
        }
    }
}

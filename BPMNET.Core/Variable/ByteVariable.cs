namespace BPMNET.Core.Variable
{
    public class ByteVariable : AbstractVariable<byte>
    {
        public override EStoreType StoreType
        {
            get { return "byte"; }
        }

        public override bool CheckForStore(object value)
        {
            if (value == null) return false;
            if (typeof(byte).IsAssignableFrom(value.GetType()))
            {
                _value = (byte)value;
            }
            else return false;
            return true;
        }
    }
}

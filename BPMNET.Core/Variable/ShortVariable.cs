namespace BPMNET.Core.Variable
{
    public class ShortVariable : AbstractVariable
    {
        public override EStoreType StoreType
        {
            get { return EStoreType.LongValue; }
        }

        public override bool CheckForStore(object value)
        {
            if (value == null) return false;
            if (typeof(short).IsAssignableFrom(value.GetType()))
            {
                Value = (short)value;
            }
            else
            {
                try
                {
                    Value = short.Parse(value.ToString());
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

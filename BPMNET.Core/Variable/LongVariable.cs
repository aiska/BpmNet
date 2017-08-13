namespace BPMNET.Core.Variable
{
    public class LongVariable : AbstractVariable
    {
        public override EStoreType StoreType
        {
            get { return EStoreType.LongValue; }
        }

        public override bool CheckForStore(object value)
        {
            if (value == null) return false;
            if (typeof(long).IsAssignableFrom(value.GetType()))
            {
                Value = (long)value;
            }
            else
            {
                try
                {
                    Value = long.Parse(value.ToString());
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

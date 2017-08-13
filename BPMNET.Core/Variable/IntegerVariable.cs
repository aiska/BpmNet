namespace BPMNET.Core.Variable
{
    public class IntegerVariable : AbstractVariable
    {
        public override EStoreType StoreType
        {
            get { return EStoreType.LongValue; }
        }

        public override bool CheckForStore(object value)
        {
            if (value == null) return false;
            if (typeof(int).IsAssignableFrom(value.GetType()))
            {
                Value = (int)value;
            }
            else
            {
                try
                {
                    Value = int.Parse(value.ToString());
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

namespace BPMNET.Core.Variable
{
    public class DecimalVariable : AbstractVariable
    {
        public override EStoreType StoreType
        {
            get { return EStoreType.DecimalValue; }
        }

        public override bool CheckForStore(object value)
        {
            if (value == null) return false;
            if (typeof(decimal).IsAssignableFrom(value.GetType()))
            {
                Value = (decimal)value;
            }
            else
            {
                try
                {
                    Value = decimal.Parse(value.ToString());
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

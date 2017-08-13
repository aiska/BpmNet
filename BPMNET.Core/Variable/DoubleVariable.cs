namespace BPMNET.Core.Variable
{
    public class DoubleVariable : AbstractVariable
    {
        public override EStoreType StoreType
        {
            get { return EStoreType.FloatValue; }
        }

        public override bool CheckForStore(object value)
        {
            if (value == null) return false;
            if (typeof(double).IsAssignableFrom(value.GetType()))
            {
                Value = (double)value;
            }
            else
            {
                try
                {
                    Value = double.Parse(value.ToString());
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

namespace BPMNET.Core.Variable
{
    public class FloatVariable : AbstractVariable
    {
        public override EStoreType StoreType
        {
            get { return EStoreType.FloatValue; }
        }

        public override bool CheckForStore(object value)
        {
            if (value == null) return false;
            if (typeof(float).IsAssignableFrom(value.GetType()))
            {
                Value = (float)value;
            }
            else
            {
                try
                {
                    Value = float.Parse(value.ToString());
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

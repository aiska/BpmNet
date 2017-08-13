using System.Linq;

namespace BPMNET.Core.Variable
{
    public class BooleanVariable : AbstractVariable<bool?>
    {
        public override EStoreType StoreType { get { return EStoreType.BitValue; } }
        public override bool? CheckForStore(object value)
        {
            bool? result = null;
            if (value == null) return result;
            if (typeof(bool).IsAssignableFrom(value.GetType()))
            {
                result = (bool)value;
            }
            else if (typeof(bool?).IsAssignableFrom(value.GetType()))
            {
                result = (bool?)value;
            }
            else
            {
                string strValue = value.ToString().Trim().ToLower();
                switch (strValue)
                {
                    case "true": result = true; break;
                    case "false": result = false; break;
                    case "1": result = true; break;
                    case "0": result = false; break;
                    default: break;
                }
            }
            return result;
        }
    }
}

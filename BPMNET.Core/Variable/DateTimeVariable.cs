using System;

namespace BPMNET.Core.Variable
{
    public class DateTimeVariable : AbstractVariable
    {
        public override EStoreType StoreType
        {
            get { return EStoreType.DateTimeValue; }
        }

        /// <summary>
        /// Check the value, if the value is correct type then the value will be stored.
        /// </summary>
        /// <param name="value">object of value</param>
        /// <returns>boolen value, if true then value will be store</returns>
        public override bool CheckForStore(object value)
        {
            if (value == null) return false;
            if (typeof(DateTime).IsAssignableFrom(value.GetType()))
            {
                Value = (DateTime)value;
            }
            else
            {
                try
                {
                    Value = DateTime.Parse(value.ToString());
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

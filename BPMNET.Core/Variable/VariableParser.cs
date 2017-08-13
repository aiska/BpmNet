using System;


namespace BPMNET.Core.Variable
{
    public static class VariableParser
    {
        public static bool? GetBool(object value, out bool stored)
        {
            bool? result = null;
            stored = false;
            if (value == null)
            {
                stored = false;
                return null;
            }
            if (typeof(bool).IsAssignableFrom(value.GetType()))
            {
                result = (bool)value;
                stored = true;
            }
            else if (typeof(bool?).IsAssignableFrom(value.GetType()))
            {
                result = (bool?)value;
                if (result.HasValue) stored = true;
            }
            else
            {
                string strValue = value.ToString().Trim().ToLower();
                switch (strValue)
                {
                    case "true": result = true; stored = true; break;
                    case "false": result = false; stored = true; break;
                    case "1": result = true; stored = true; break;
                    case "0": result = false; stored = true; break;
                    default: break;
                }
            }
            return result;
        }

        public static long? GetLong(object value, out bool stored)
        {
            long? result = null;
            stored = false;
            if (value == null)
            {
                stored = false;
                return null;
            }
            if (typeof(long).IsAssignableFrom(value.GetType()))
            {
                result = (long)value;
                stored = true;
            }
            else if (typeof(long?).IsAssignableFrom(value.GetType()))
            {
                result = (long?)value;
                if (result.HasValue) stored = true;
            }
            else
            {
                try
                {
                    result = long.Parse(value.ToString());
                }
                catch (System.Exception)
                {
                    stored = false;
                }
            }
            return result;
        }

        public static decimal? GetDecimal(object value, out bool stored)
        {
            decimal? result = null;
            stored = false;
            if (value == null)
            {
                stored = false;
                return null;
            }
            if (typeof(decimal).IsAssignableFrom(value.GetType()))
            {
                result = (decimal)value;
                stored = true;
            }
            else if (typeof(decimal?).IsAssignableFrom(value.GetType()))
            {
                result = (decimal?)value;
                if (result.HasValue) stored = true;
            }
            else
            {
                try
                {
                    result = decimal.Parse(value.ToString());
                }
                catch (System.Exception)
                {
                    stored = false;
                }
            }
            return result;
        }

        public static float? GetFloat(object value, out bool stored)
        {
            float? result = null;
            stored = false;
            if (value == null)
            {
                stored = false;
                return null;
            }
            if (typeof(float).IsAssignableFrom(value.GetType()))
            {
                result = (float)value;
                stored = true;
            }
            else if (typeof(float?).IsAssignableFrom(value.GetType()))
            {
                result = (float?)value;
                if (result.HasValue) stored = true;
            }
            else
            {
                try
                {
                    result = float.Parse(value.ToString());
                }
                catch (System.Exception)
                {
                    stored = false;
                }
            }
            return result;
        }

        public static DateTime? GetDateTime(object value, out bool stored)
        {
            DateTime? result = null;
            stored = false;
            if (value == null)
            {
                stored = false;
                return null;
            }
            if (typeof(DateTime).IsAssignableFrom(value.GetType()))
            {
                result = (DateTime)value;
                stored = true;
            }
            else if (typeof(DateTime?).IsAssignableFrom(value.GetType()))
            {
                result = (DateTime?)value;
                if (result.HasValue) stored = true;
            }
            else
            {
                try
                {
                    result = DateTime.Parse(value.ToString());
                }
                catch (System.Exception)
                {
                    stored = false;
                }
            }
            return result;
        }
    }
}

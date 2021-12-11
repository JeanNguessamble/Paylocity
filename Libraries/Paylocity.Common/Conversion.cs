using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Common
{
    public class Conversion
    {
        public static T ToEnum<T>(object value)
        {
            if (value == null) return default(T);
            string _value = Convert.ToString(value);
            if (string.IsNullOrEmpty(_value)) return default(T);
            return Enums.Convert<T>(_value);
        }
        public static T JsonToType<T>(object json_string)
        {
            try
            {
                if (json_string == null || string.IsNullOrEmpty(json_string.ToString())) return default(T);
                return JsonConvert.DeserializeObject<T>(json_string.ToString());
            }
            catch { return default(T); }
        }
        public static string TypeToJson<T>(T json_entity)
        {
            try
            {
                return JsonConvert.SerializeObject(json_entity);
            }
            catch { return null; }
        }
    }
}

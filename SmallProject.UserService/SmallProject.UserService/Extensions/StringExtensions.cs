using GraphQL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace SmallProject.UserService.Extensions
{
    public static class StringExtensions
    {
        public static Inputs ToInputs(this JObject obj)
        {
            var variables = obj?.GetValue() as Dictionary<string, object>
                            ?? new Dictionary<string, object>();
            return new Inputs(variables);
        }

        public static Dictionary<string, object> ToDictionary(this string json)
        {
            // Deserializes the JSON to a .NET object.
            var values = JsonConvert.DeserializeObject(json,
                new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateParseHandling = DateParseHandling.None
                });

            return GetValue(values) as Dictionary<string, object>;
        }

        public static object GetValue(this object value)
        {
            // JObject: represents a JSON Object
            var objectValue = value as JObject;
            if (objectValue != null)
            {
                var output = new Dictionary<string, object>();
                foreach (var kvp in objectValue)
                {
                    output.Add(kvp.Key, GetValue(kvp.Value));
                }
                return output;
            }

            var propertyValue = value as JProperty;
            if (propertyValue != null)
            {
                return new Dictionary<string, object>
                {
                    { propertyValue.Name, GetValue(propertyValue.Value) }
                };
            }

            var arrayValue = value as JArray;
            if (arrayValue != null)
            {
                return arrayValue.Children().Aggregate(new List<object>(), (list, token) =>
                {
                    list.Add(GetValue(token));
                    return list;
                });
            }

            var rawValue = value as JValue;
            if (rawValue != null)
            {
                var val = rawValue.Value;
                if (val is long)
                {
                    long l = (long)val;
                    if (l >= int.MinValue && l <= int.MaxValue)
                    {
                        return (int)l;
                    }
                }
                return val;
            }

            return value;
        }
    }
}

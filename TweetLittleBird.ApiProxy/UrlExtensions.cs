using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TweetLittleBird.ApiProxy
{
    public static class UrlExtensions
    {
        public static string ToQueryString(this object request)
        {
            if (request == null) throw new ArgumentNullException("request");

            // Get all properties on the object
            var propertyInfos = request
                .GetType().GetProperties()
                .Where(x => x.CanRead)
                .Where(x => x.GetCustomAttributes(typeof(JsonIgnoreAttribute), true).Length == 0)
                .Where(x =>
                {
                    // This is a result of MoneyMatchRequest.RequestedProductCode
                    // throws exceptions for some of the implementations.
                    try { return x.GetValue(request, null) != null; }
                    catch { }
                    return false;
                }).ToArray();

            var properties = new Dictionary<string, object>();
            foreach (var propertyInfo in propertyInfos)
            {
                if (!properties.ContainsKey(propertyInfo.Name))
                {
                    properties.Add(propertyInfo.Name, propertyInfo.GetValue(request, null));
                }
            }

            // Concat all key/value pairs into a string separated by ampersand
            return string.Concat("?", string.Join("&", properties.SelectMany(GetPairs)));
        }

        private static IEnumerable<string> GetPairs(KeyValuePair<string, object> keyValuePair)
        {
            if (keyValuePair.Value is string || !(keyValuePair.Value is IEnumerable))
            {
                yield return string.Concat(
                    Uri.EscapeDataString(keyValuePair.Key), "=",
                    Uri.EscapeDataString(keyValuePair.Value.ToString()));
            }
            else
            {
                var enumerable = keyValuePair.Value as IEnumerable;
                foreach (var value in enumerable)
                {
                    var valueType = value.GetType();
                    if (valueType.IsPrimitive || valueType == typeof(string))
                    {
                        yield return string.Concat(
                            Uri.EscapeDataString(keyValuePair.Key), "=",
                            Uri.EscapeDataString(value.ToString()));
                    }
                }

            }
        }
    }
}
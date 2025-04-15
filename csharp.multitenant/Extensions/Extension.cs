using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace csharp.multitenant.Extensions
{
    public static class Extension
    {
        public static string ToJson(this object obj) => JsonConvert.SerializeObject(obj, Formatting.Indented);

        public static T? ToObject<T>(this string jsonStr) => JsonConvert.DeserializeObject<T>(jsonStr);
    }
}

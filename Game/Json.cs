using Newtonsoft.Json;

namespace GameLibrary
{
    public class Json
    {
        public static string SerializeWithTypeHandling(object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        }
        public static T DeserializeWithTypeHandling<T>(string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        }
        public static string SerializeWithoutTypeHandling(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}

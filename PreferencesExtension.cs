using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MauiNfcHceBootStrapExample
{    

    // All the code in this file is included in all platforms.
    public static class PreferencesExtension
    {
        public static void SetObject<T>(string key, T obj)
        {
            SetObject<T>(Preferences.Default, key, obj);
        }

        public static void SetObject<T>(this IPreferences preferences, string key, T obj)
        {
            string jsonValue = null;

            if (obj != null)
            {
                jsonValue = JsonConvert.SerializeObject(obj);
            }

            preferences.Set<string>(key, jsonValue);
        }

        public static T GetObject<T>(string key, T defaultValue)
        {
            return GetObject<T>(Preferences.Default, key, defaultValue);
        }

        public static T GetObject<T>(this IPreferences preferences, string key, T defaultValue)
        {
            string jsonValue = preferences.Get<string>(key, null);

            if (jsonValue == null)
            {
                return defaultValue;
            }

            return JsonConvert.DeserializeObject<T>(jsonValue, new JsonSerializerSettings() { ObjectCreationHandling = ObjectCreationHandling.Replace });            
        }
    }
}

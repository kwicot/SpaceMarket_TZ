using System;
using UnityEngine;

namespace Core.Scripts.Geo
{
    [Serializable]
    public class IpApiData
    {
        public string country_code;
        public string country_name;

        public CountryISO CountryISO
        {
            get
            {
                if (CountryISO.TryParse(country_code, out CountryISO value))
                    return value;
                
                throw new NullReferenceException($"Cant find country with code {country_code}");
            }
        }

        public static IpApiData CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<IpApiData>(jsonString);
        }
    }
}
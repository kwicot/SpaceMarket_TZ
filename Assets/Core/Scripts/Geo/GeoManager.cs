using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Core.Scripts.Geo
{
    public class GeoManager
    {
       static string ip = new System.Net.WebClient().DownloadString("https://api.ipify.org");
       static string uri = $"https://ipapi.co/{ip}/json/";
        
        public static async Task<IpApiData> GetCountry()
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                await webRequest.SendWebRequest();
                IpApiData ipApiData = IpApiData.CreateFromJSON(webRequest.downloadHandler.text);
                return ipApiData;
            }
        }
    }
}
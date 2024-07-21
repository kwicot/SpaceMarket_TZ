using System;
using System.Threading.Tasks;
using Core.Scripts.Geo;
using Core.Scripts.GPM;
using SpaceMarket.Core.Scripts.Popup.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Core.Scripts
{
    public class AppService : MonoBehaviour
    {
        [SerializeField] private SceneReference menuScene;
        [Inject] private PopupLoadingService _loadingService;
        
        private async void Start()
        {
            WebView.OnClose += OnWebViewClose; //TODO переробити якщо треба не тільки тут
            
            _loadingService.Show();
            await Task.Delay(3000);
            
            if(Application.internetReachability == NetworkReachability.NotReachable)
            {
                while (Application.internetReachability == NetworkReachability.NotReachable)
                {
                    await Task.Delay(200);
                }
            }
            
            
            var countryData = await GeoManager.GetCountry();
            await _loadingService.Hide();

            Debug.Log($"Country {countryData.CountryISO}");
            if (countryData.CountryISO == CountryISO.UA)
            {
                SceneManager.LoadScene(menuScene);
            }
            else
            {
                WebView.ShowUrlFullScreen("https://uk.wikipedia.org/wiki/");
            }
        }

        private void OnDestroy()
        {
            WebView.OnClose -= OnWebViewClose;
        }

        private void OnWebViewClose()
        {
            Application.Quit();
        }
    }
}
using System.Threading.Tasks;
using Core.Scripts.Geo;
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
            _loadingService.Show();
            await Task.Delay(3000);
            var countryData = await GeoManager.GetCountry();
            await _loadingService.Hide();
            
            if (countryData.CountryISO == CountryISO.UA)
            {
                SceneManager.LoadScene(menuScene);
            }
            else
            {
            }
        }
    }
}
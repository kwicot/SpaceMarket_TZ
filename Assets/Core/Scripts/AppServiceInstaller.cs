using Core.Scripts;
using SpaceMarket.Core.Scripts.Popup.UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace SpaceMarket.Core.Scipts
{
    public class AppServiceInstaller : MonoInstaller
    {
        [SerializeField] private AppService appServicePrefab;
        [SerializeField] private PopupLoadingService popupLoadingServicePrefab;

        public override void InstallBindings()
        {
            Container.Bind<PopupLoadingService>().FromComponentInNewPrefab(popupLoadingServicePrefab).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<AppService>().FromComponentInNewPrefab(appServicePrefab).AsSingle().NonLazy();
        }
    }
}
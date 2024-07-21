using UnityEngine;
using Zenject;

namespace SpaceMarket.Core.Scripts.Popup.UI
{
    public class PopupLoadingServiceInstaller : MonoInstaller
    {
        [SerializeField] private PopupLoadingService popupLoadingServicePrefab;
        public override void InstallBindings()
        {
            Debug.Log("Install bindings");
            Container.BindInterfacesAndSelfTo<PopupLoadingService>().FromComponentInNewPrefab(popupLoadingServicePrefab).AsSingle().NonLazy();
        }
    }
}
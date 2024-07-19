using UnityEngine;
using Zenject;

namespace SpaceMarket.Core.Scripts.Popup.UI
{
    public class PopupServiceInstaller : MonoInstaller
    {
        [SerializeField] private PopupLoadingService popupLoadingServicePrefab;
        public override void InstallBindings()
        {
            Container.Bind<IPopupService>().To<PopupLoadingService>().FromComponentInNewPrefab(popupLoadingServicePrefab).AsSingle();
        }
    }
}
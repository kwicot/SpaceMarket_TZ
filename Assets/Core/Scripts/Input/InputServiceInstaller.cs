using UnityEngine;
using Zenject;

namespace SpaceMarket.Core.Scripts.Obstacles.UI
{
    public class InputServiceInstaller : MonoInstaller
    {
        [SerializeField] private MouseInputService mouseInputServicePrefab;
        [SerializeField] private TouchInputService touchInputServicePrefab;
        public override void InstallBindings()
        {
            if (SystemInfo.deviceType == DeviceType.Desktop)
            {
                Container.Bind<IMovementInputService>().To<MouseInputService>()
                    .FromComponentInNewPrefab(mouseInputServicePrefab).AsSingle();
            }
            else
            {
                Container.Bind<IMovementInputService>().To<TouchInputService>()
                    .FromComponentInNewPrefab(touchInputServicePrefab).AsSingle();
            }

        }
    }
}
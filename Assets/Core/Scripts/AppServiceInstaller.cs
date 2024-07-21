using Core.Scripts;
using UnityEngine;
using Zenject;

namespace SpaceMarket.Core.Scipts
{
    public class AppServiceInstaller : MonoInstaller
    {
        [SerializeField] private AppService appService; 
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AppService>().FromComponentInNewPrefab(appService).AsSingle().NonLazy();
        }
    }
}
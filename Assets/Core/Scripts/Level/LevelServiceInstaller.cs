using UnityEngine;
using Zenject;

namespace SpaceMarket.Core.Scipts
{
    public class LevelServiceInstaller : MonoInstaller
    {
        [SerializeField] private LevelService levelService;
        public override void InstallBindings()
        {
            Container.Bind<LevelService>().FromInstance(levelService).AsSingle();
        }
    }
}
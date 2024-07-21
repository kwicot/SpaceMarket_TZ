using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Core.Scripts.Collectable
{
    public class CollectableSpawnServiceInstaller : MonoInstaller
    {
        [SerializeField] private CollectableSpawnService collectableSpawnService;
        public override void InstallBindings()
        {
            Container.Bind<CollectableSpawnService>().FromInstance(collectableSpawnService).AsSingle().NonLazy();
        }
    }
}
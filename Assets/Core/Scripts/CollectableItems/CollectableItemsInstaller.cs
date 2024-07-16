using UnityEngine;
using Zenject;

namespace Core.Scripts.Collectable
{
    public class CollectableItemsInstaller : MonoInstaller
    {
        [SerializeField] private CollectableSpawnController collectableSpawnController;
        public override void InstallBindings()
        {
            Container.Bind<CollectableSpawnController>().FromInstance(collectableSpawnController).AsSingle();
        }
    }
}
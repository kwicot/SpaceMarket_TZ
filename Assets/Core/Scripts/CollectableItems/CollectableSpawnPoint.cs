using System;
using SpaceMarket.Core.Scipts.Extensions;
using ToolBox.Pools;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.Scripts.Collectable
{
    public class CollectableSpawnPoint : MonoBehaviour
    {
        [SerializeField][Range(0,100)] private int spawnChance;

        private CollectableSpawnController _spawnController;

        [Inject]
        void Construct(CollectableSpawnController spawnController)
        {
            _spawnController = spawnController;
        }

        private void OnEnable()
        {
            int r = Random.Range(0, 100);
            if (r >= spawnChance)
            {
                var obj = _spawnController.GetRandom();
                obj.Reuse(transform.position, Quaternion.identity);
                obj.Enable();
            }
        }
    }
}
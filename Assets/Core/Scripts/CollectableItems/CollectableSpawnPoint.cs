using SpaceMarket.Core.Scripts.Extensions;
using ToolBox.Pools;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.Scripts.Collectable
{
    public class CollectableSpawnPoint : MonoBehaviour
    {
        [SerializeField][Range(0,100)] private int spawnChance;
        [SerializeField] private Vector3 spawnOffset;

        [Inject]private CollectableSpawnService _spawnService;

        private void Start()
        {
            int r = Random.Range(0, 100);
            if (r <= spawnChance)
            {
                var obj = _spawnService.GetRandom();
                obj.Reuse(transform.position + spawnOffset, Quaternion.identity);
                obj.Enable();
            }
        }

        private async void OnEnable()
        {
            
        }

    }
}
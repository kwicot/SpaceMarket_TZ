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

        [Inject]private CollectableSpawnService _spawnService;

        private void Start()
        {
            int r = Random.Range(0, 100);
            if (r >= spawnChance)
            {
                //await Task.Delay(100); //Рішення для прототипу. В повноцінній версії такого костиля не має бути бо треба писати нормальний спавнер, а не як тут)))
                var obj = _spawnService.GetRandom();
                obj.Reuse(transform.position, Quaternion.identity);
                obj.Enable();
            }
        }

        private async void OnEnable()
        {
            
        }

    }
}
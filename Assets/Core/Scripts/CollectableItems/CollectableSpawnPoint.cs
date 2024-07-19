using SpaceMarket.Core.Scripts.Extensions;
using ToolBox.Pools;
using UnityEditor.VersionControl;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;
using Task = System.Threading.Tasks.Task;

namespace Core.Scripts.Collectable
{
    public class CollectableSpawnPoint : MonoBehaviour
    {
        [SerializeField][Range(0,100)] private int spawnChance;

        [Inject]private CollectableSpawnService _spawnService;
        

        private async void OnEnable()
        {
            int r = Random.Range(0, 100);
            if (r >= spawnChance)
            {
                await Task.Delay(100); //Рішення для прототипу. В повноцінній версії такого костиля не має бути бо треба писати нормальний спавнер, а не як тут)))
                Debug.Log(_spawnService.name);
                var obj = _spawnService.GetRandom();
                obj.Reuse(transform.position, Quaternion.identity);
                obj.Enable();
            }
        }
    }
}
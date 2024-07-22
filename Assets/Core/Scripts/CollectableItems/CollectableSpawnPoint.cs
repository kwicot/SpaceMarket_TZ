using System.Threading.Tasks;
using SpaceMarket.Core.Scripts.Extensions;
using ToolBox.Pools;
using Unity.VisualScripting;
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


        private async void OnEnable()
        {
            await Task.Delay(200); //Костиль. На ліпший варіант треба більше часу. Для тестового підійде. В ідеалі треба прописати ініціалізацію в скрипт платформи
            int r = Random.Range(0, 100);
            Debug.Log($"R: {r} chance: {spawnChance}");
            if (r <= spawnChance)
            {
                var obj = _spawnService.GetRandom();
                obj.Reuse(transform.position + spawnOffset, Quaternion.identity);
                obj.Enable();
                Debug.Log(obj.name);
            }
        }

    }
}
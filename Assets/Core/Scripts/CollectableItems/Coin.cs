using SpaceMarket.Core.Scripts;
using ToolBox.Pools;
using UnityEngine;
using Zenject;

namespace Core.Scripts.Collectable
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Coin : MonoBehaviour, ICollectableItem
    {
        [SerializeField] int score;
        public int Score => score;

        [Inject]private LevelService _levelService;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _levelService.OnPlayerCollect(this);
                gameObject.Release();
            }
        }

    }
}
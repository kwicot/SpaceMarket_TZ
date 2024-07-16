using SpaceMarket.Core.Scipts;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Core.Scripts
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Coin : MonoBehaviour, ICollectableItem
    {
        [SerializeField] int score;
        public int Score => score;

        [Inject]private LevelService _levelService;
        
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log($"Collision with {other.gameObject.name}");
            if (other.gameObject.CompareTag("Obstacle"))
            {
                _levelService.OnPlayerHit();
            }
        }

    }
}
using SpaceMarket.Core.Scripts;
using ToolBox.Pools;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Core.Scripts.Collectable
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Coin : MonoBehaviour, ICollectableItem
    {
        [SerializeField] int scoreGain;
        public int ScoreGain => scoreGain;

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
using System;
using UnityEngine;
using Zenject;

namespace SpaceMarket.Core.Scripts.Obstacles
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class PlayerTrigger : MonoBehaviour
    {
        [Inject] private LevelService _levelService;
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log($"Collision {other.gameObject.tag}");
            if (other.gameObject.CompareTag("Obstacle"))
            {
                _levelService.OnPlayerHit();
            }
        }
    }
}
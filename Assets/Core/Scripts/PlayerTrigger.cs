using System;
using UnityEngine;
using Zenject;

namespace SpaceMarket.Core.Scipts.Obstacles
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class PlayerTrigger : MonoBehaviour
    {
        [Inject] private LevelService _levelService;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                _levelService.OnPlayerHit();
            }
        }
    }
}
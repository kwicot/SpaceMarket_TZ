using System;
using UnityEngine;

namespace SpaceMarket.Core.Scipts.Obstacles
{
    public class PlayerTrigger : MonoBehaviour
    {
        [SerializeField] private LevelManager _levelManager;
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log($"Collision with {other.gameObject.name}");
            if (other.gameObject.CompareTag("Obstacle"))
            {
                _levelManager.OnPlayerHit();
            }
        }
    }
}
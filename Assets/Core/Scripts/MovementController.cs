using System;
using UnityEngine;

namespace SpaceMarket.Core.Scipts.Obstacles
{
    
    [RequireComponent(typeof(Rigidbody))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float horizontalSpeed;

        private Rigidbody _rigidbody;

        private void Start()
        {
            if (!TryGetComponent(out _rigidbody))
                throw new NullReferenceException($"Cant find rigidbody on {name}");
        }
        

        private void FixedUpdate()
        {
            Vector3 velocity = _rigidbody.velocity;
            var dif = moveSpeed = velocity.magnitude;
            var force = velocity * dif;
            _rigidbody.AddForce(force);

        }
    }
}
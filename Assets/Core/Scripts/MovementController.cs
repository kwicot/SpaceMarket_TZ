using System;
using UnityEngine;

namespace SpaceMarket.Core.Scipts.Obstacles
{
    
    [RequireComponent(typeof(Rigidbody))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private Rigidbody _rigidbody;

        private void Start()
        {
            if (!TryGetComponent(out _rigidbody))
                throw new NullReferenceException($"Cant find rigidBody on {name}");

            _rigidbody.velocity = new Vector3(0, 0, moveSpeed * Time.fixedDeltaTime);
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
using System;
using SpaceMarket.Core.Scipts.Obstacles.UI;
using UnityEngine;
using Zenject;

namespace SpaceMarket.Core.Scipts.Obstacles
{
    
    [RequireComponent(typeof(Rigidbody))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float multiplier;
        [SerializeField] private float positionY;

        private Rigidbody _rigidbody;

        private IMovementInputService _movementInputService;

        private float _positionX;
        private float _positionZ;


        [Inject]
        void Construct(IMovementInputService movementInputService)
        {
            _movementInputService = movementInputService;
        }
        private void Start()
        {
            if (!TryGetComponent(out _rigidbody))
                throw new NullReferenceException($"Cant find rigidBody on {name}");
        }

        private void Update()
        {
            if (levelManager.IsPlay)
            {
                _movementInputService.UpdateInput();
                _positionX = _movementInputService.Horizontal;
            }
        }

        private void FixedUpdate()
        {
            if (levelManager.IsPlay)
            {
                _positionZ = transform.position.z;
                _positionZ += moveSpeed * Time.fixedDeltaTime;
                

                var position = new Vector3(_positionX, positionY, _positionZ);
                _rigidbody.MovePosition(position);
            }
        }
    }
}
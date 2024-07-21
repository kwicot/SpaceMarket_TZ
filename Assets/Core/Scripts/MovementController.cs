using System;
using System.ComponentModel;
using SpaceMarket.Core.Scripts.Obstacles.UI;
using UnityEngine;
using Zenject;

namespace SpaceMarket.Core.Scripts.Obstacles
{
    
    [RequireComponent(typeof(Rigidbody))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float positionY;
        [SerializeField] private float minPositionX;
        [SerializeField] private float maxPositionX;

        private Rigidbody _rigidbody;

        private IMovementInputService _movementInputService;
        private LevelService _levelService;


        private float _positionX;
        private float _positionZ;
        private float _screenSizeX;


        [Inject]
        void Construct(IMovementInputService movementInputService, LevelService levelService)
        {
            _movementInputService = movementInputService;
            _levelService = levelService;
        }
        private void Start()
        {
            if (!TryGetComponent(out _rigidbody))
                throw new NullReferenceException($"Cant find rigidBody on {name}");
        }

        private void Update()
        {
            if (_levelService.IsPlaying)
            {
                _movementInputService.UpdateInput();
                _positionX = _movementInputService.Horizontal;
                if(_positionX < minPositionX) _positionX = minPositionX;
                if(_positionX > maxPositionX) _positionX = maxPositionX;
            }
        }

        private void FixedUpdate()
        {
            if (_levelService.IsPlaying)
            {
                _positionZ = transform.position.z;
                _positionZ += moveSpeed * Time.fixedDeltaTime;
                
                var position = new Vector3(_positionX, positionY, _positionZ);
                _rigidbody.MovePosition(position);
            }
        }
    }
}
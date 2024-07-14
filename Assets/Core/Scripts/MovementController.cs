using System;
using UnityEngine;
using UnityEngine.Serialization;

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

        private float _positionX;
        private float _positionZ;
        private float _mouseInputOffset;
        
        private void Start()
        {
            if (!TryGetComponent(out _rigidbody))
                throw new NullReferenceException($"Cant find rigidBody on {name}");

            _mouseInputOffset = Screen.width / 2f;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                _positionX = Input.mousePosition.x - _mouseInputOffset;
                _positionX *= multiplier;
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
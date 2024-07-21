using System;
using UnityEngine;
using Zenject;

namespace SpaceMarket.Core.Scripts.Animations
{
    public class RotationAnimation : MonoBehaviour
    {
        [SerializeField] private Vector3 rotationAxis;
        
        [Inject] private LevelService _levelService;

        private Rigidbody _body;

        private void Start()
        {
            TryGetComponent(out _body);
        }
        

        private void FixedUpdate()
        {
            if (_levelService.IsPlaying)
            {
                var rotation = transform.rotation.eulerAngles;
                rotation += rotationAxis * Time.fixedDeltaTime;
                if (_body)
                    _body.MoveRotation(Quaternion.Euler(rotation));
                else
                    transform.Rotate(rotation);
            }
        }
    }
}

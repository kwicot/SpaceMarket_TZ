using System;
using UnityEngine;

namespace SpaceMarket.Core.Scripts.Animations
{
    public class RotationAnimation : MonoBehaviour
    {
        [SerializeField] private Vector3 rotationAxis;

        private Rigidbody _body;

        private void Start()
        {
            TryGetComponent(out _body);
        }

        private void FixedUpdate()
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

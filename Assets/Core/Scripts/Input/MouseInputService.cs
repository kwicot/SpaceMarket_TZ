using System;
using UnityEngine;

namespace SpaceMarket.Core.Scipts.Obstacles.UI
{
    public class MouseInputService : MonoBehaviour, IMovementInputService
    {
        [SerializeField] private float multiplier;
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        private float _inputOffset;

        private void Start()
        {
            _inputOffset = Screen.width / 2f;
        }
        
        public void UpdateInput()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Horizontal = Input.mousePosition.x - _inputOffset;
                Horizontal *= multiplier;
            }
        }
    }
}
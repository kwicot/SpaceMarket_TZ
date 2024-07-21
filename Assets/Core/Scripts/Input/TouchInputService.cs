using System;
using Unity.VisualScripting;
using UnityEngine;

namespace SpaceMarket.Core.Scripts.Obstacles.UI
{
    public class TouchInputService : MonoBehaviour, IMovementInputService
    {
        [SerializeField] private float multiplier;

        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        private float _inputOffset;
        private float _screenSize;

        private void Start()
        {
            _screenSize = Screen.width;
            _inputOffset = _screenSize / 2f;
        }
        
        public void UpdateInput()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                Horizontal = touch.position.x - _inputOffset;
                Horizontal *= multiplier;
            }
            
        }
    }
}
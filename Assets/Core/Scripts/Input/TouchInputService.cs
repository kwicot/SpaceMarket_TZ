using System;
using Unity.VisualScripting;
using UnityEngine;

namespace SpaceMarket.Core.Scipts.Obstacles.UI
{
    public class TouchInputService : MonoBehaviour, IMovementInputService
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
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                Horizontal = touch.position.x - _inputOffset;
                Horizontal *= multiplier;
            }
            
        }
    }
}
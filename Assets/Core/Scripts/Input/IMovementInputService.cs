using UnityEngine;

namespace SpaceMarket.Core.Scipts.Obstacles.UI
{
    public interface IMovementInputService
    {
        public float Horizontal { get; }
        public float Vertical { get; }
        public void UpdateInput();
    }
}
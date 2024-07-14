using UnityEngine;

namespace SpaceMarket.Core.Scipts.Obstacles
{
    public class LevelManager : MonoBehaviour
    {
        public bool IsPlay { get;  set; }

        public void OnPlayerHit()
        {
            IsPlay = false;
            Debug.Log("Lose");
        }
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceMarket.Core.Scipts.UI
{
    public class GameHud : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text coinsText;
        
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button menuButton;


        public void Play()
        {
            
        }
    }
}
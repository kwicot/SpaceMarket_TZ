using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SpaceMarket.Core.Scipts.Obstacles.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button exitButton;

        private async void Start()
        {
            
        }

        public void Play()
        {
            SceneManager.LoadSceneAsync("Game");
        }

        public void Exit()
        {
            Application.Quit();
        }
}
}
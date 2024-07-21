using System;
using SpaceMarket.Core.Scipts.Extensions;
using SpaceMarket.Core.Scripts.Popup.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace SpaceMarket.Core.Scripts.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private SceneReference gameScene;
        [Inject] private PopupLoadingService _loadingService;


        private void Start()
        {
            if (_loadingService.IsShowing)
                _loadingService.Hide();
            
            playButton.RemoveAllListeners().AddListener(Play);
            exitButton.RemoveAllListeners().AddListener(Exit);
        }

        private void OnDestroy()
        {
            playButton.RemoveAllListeners();
            exitButton.RemoveAllListeners();
        }


        public async void Play()
        {
            await _loadingService.Show();
            SceneManager.LoadSceneAsync(gameScene);
        }

        public void Exit()
        {
            Application.Quit();
        }
}
}
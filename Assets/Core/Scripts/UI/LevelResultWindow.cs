using System;
using SpaceMarket.Core.Scipts.Extensions;
using SpaceMarket.Core.Scipts.UI;
using SpaceMarket.Core.Scripts;
using SpaceMarket.Core.Scripts.Popup.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Core.Scripts.UI
{
    public class LevelResultWindow : Window
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;
        
        [Inject] private PopupLoadingService _loadingService;
        [Inject] private AppService _appService;
        [Inject] private LevelService _levelService;

        protected override void OnStart()
        {
            restartButton.RemoveAllListeners().AddListener(Restart);
            menuButton.RemoveAllListeners().AddListener(Return);

            _levelService.OnEndGame += OnEndGame;
        }

        private void OnEndGame()
        {
            Debug.Log("OnEndGame");
            Show();
        }

        private void OnDestroy()
        {
            restartButton.RemoveAllListeners();
            menuButton.RemoveAllListeners();
            
            _levelService.OnEndGame -= OnEndGame;

        }

        private async void Return()
        {
            await _loadingService.Show();
            SceneManager.LoadScene(_appService.menuScene);
        }

        private async void Restart()
        {
            await _loadingService.Show();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }

        protected override void OnShow()
        {
            scoreText.text = $"Score: {_levelService.Score}";
        }

        protected override void OnHide()
        {
            
        }
    }
}
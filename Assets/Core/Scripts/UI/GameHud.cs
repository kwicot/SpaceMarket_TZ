using System;
using Core.Scripts;
using SpaceMarket.Core.Scipts.Extensions;
using SpaceMarket.Core.Scripts.Extensions;
using SpaceMarket.Core.Scripts.Popup.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace SpaceMarket.Core.Scripts.UI
{
    public class GameHud : MonoBehaviour
    {
        [SerializeField] private GameObject rootPanel;
        [SerializeField] private TMP_Text scoreText;
        
        [SerializeField] private Button menuButton;
        [SerializeField] private Button pauseButton;

        [SerializeField] private Sprite pauseSprite;
        [SerializeField] private Sprite playSprite;
        
        [Inject] private LevelService _levelService;
        [Inject] private PopupLoadingService _loadingService;
        [Inject] private AppService _appService;

        private async void Start()
        {
            pauseButton.RemoveAllListeners().AddListener(OnPauseClick);
            menuButton.RemoveAllListeners().AddListener(OnMenuClick);
            
            _levelService.OnScoreChanged += OnScoreChanged;
            _levelService.OnEndGame += OnEndGame;
            
            if (_loadingService.IsShowing)
                await _loadingService.Hide();
            
            _levelService.Play();
            OnScoreChanged();
        }

        private void OnEndGame()
        {
            rootPanel.Disable();
        }

        private void OnDestroy()
        {
            pauseButton.RemoveAllListeners();
            menuButton.RemoveAllListeners();
            
            _levelService.OnScoreChanged -= OnScoreChanged;
            _levelService.OnEndGame -= OnEndGame;
        }

        private void OnScoreChanged()
        {
            scoreText.text = $"Score: {_levelService.Score}";
        }

        void OnPauseClick()
        {
            if (_levelService.IsPlaying)
            {
                _levelService.Pause();
                pauseButton.image.sprite = playSprite;
            }
            else
            {
                _levelService.Play();
                pauseButton.image.sprite = pauseSprite;
            }
        }

        private async void OnMenuClick()
        {
            await _loadingService.Show();
            SceneManager.LoadScene(_appService.menuScene);
        }
    }
}
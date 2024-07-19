using System;
using SpaceMarket.Core.Scipts.Extensions;
using TMPro;
using UnityEngine;
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

        private void Start()
        {
            pauseButton.RemoveAllListeners();
            pauseButton.AddListener(OnPauseClick);
            
            menuButton.RemoveAllListeners();
            menuButton.AddListener(OnMenuClick);
            _levelService.OnScoreChanged += OnScoreChanged;
        }

        private void OnDestroy()
        {
            pauseButton.RemoveAllListeners();
            menuButton.RemoveAllListeners();
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

        void OnMenuClick()
        {
            
        }
    }
}
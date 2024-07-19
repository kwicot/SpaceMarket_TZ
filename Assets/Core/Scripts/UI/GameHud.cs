using SpaceMarket.Core.Scipts.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace SpaceMarket.Core.Scipts.UI
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
            menuButton.RemoveAllListeners();
            menuButton.AddListener(OnPauseClick);
            _levelService.OnScoreChanged += OnScoreChanged;
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
    }
}
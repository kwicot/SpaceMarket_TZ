using Core.Scripts.Collectable;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceMarket.Core.Scripts
{
    public class LevelService : MonoBehaviour
    {
        private int _score;
        bool _isPlaying = false;

        
        public int Score
        {
            get { return _score; }
            private set
            {
                _score = value;
                OnScoreChanged?.Invoke();
            }
        }

        public bool IsPlaying
        {
            get { return _isPlaying; }
            private set
            {
                _isPlaying = value;
                OnPlayingStateChanged?.Invoke();
            }
        }
        
        
        
        public UnityAction OnPlayingStateChanged;
        public UnityAction OnScoreChanged;


        public void Play()
        {
            IsPlaying = true;
        }
        
        public void OnPlayerHit()
        {
            IsPlaying = false;
            Debug.Log("Lose");
        }

        public void OnPlayerCollect(ICollectableItem item)
        {
            Score += item.Score;
        }
    }
}
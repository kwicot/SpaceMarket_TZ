﻿using System;
using Core.Scripts.Collectable;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceMarket.Core.Scripts
{
    public class LevelService : MonoBehaviour
    {
        private int _score;
        private bool _isPlaying;
        
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
        public UnityAction OnEndGame;


        public void Play()
        {
            IsPlaying = true;
        }

        public void Pause()
        {
            IsPlaying = false;
        }

        public void OnPlayerHit()
        {
            IsPlaying = false;
            OnEndGame?.Invoke();
        }

        public void OnPlayerCollect(ICollectableItem item)
        {
            Score += item.ScoreGain;
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            Pause();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if(hasFocus)
                Play();
            else
                Pause();
        }
    }
}
using System;
using UnityEngine;

namespace SpaceMarket.Core.Scipts.UI
{
    public abstract class Window : MonoBehaviour
    {
        protected IWindowAnimation[] _windowAnimations;

        private void Start()
        {
            _windowAnimations = GetComponentsInChildren<IWindowAnimation>();
            OnStart();
        }


        public void Show()
        {
            foreach (var windowAnimation in _windowAnimations)
                windowAnimation.PlayShowAnimation();
            
            OnShow();
        }

        public void Hide()
        {
            OnHide();
            
            foreach (var windowAnimation in _windowAnimations)
                windowAnimation.PlayHideAnimation();
        }
        protected virtual void OnStart(){}
        
        protected abstract void OnShow();
        protected abstract void OnHide();
    }
}
using UnityEngine;

namespace SpaceMarket.Core.Scipts.UI
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField]
        protected GameObject _rootPanel;
        protected IWindowAnimation[] _windowAnimations;

        private void Start()
        {
            _windowAnimations = _rootPanel.GetComponentsInChildren<IWindowAnimation>();
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
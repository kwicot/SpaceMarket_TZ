using DG.Tweening;
using SpaceMarket.Core.Scripts.Extensions;
using UnityEngine;

namespace SpaceMarket.Core.Scripts.Popup.UI
{
    public class PopupLoadingService : MonoBehaviour, IPopupService
    {
        [SerializeField] private GameObject rootPanel;
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] float fadeDuration = 0.5f;
        
        public void Show()
        {
            rootPanel.Enable();
            canvasGroup.DOFade(1, fadeDuration);
        }

        public void Close()
        {
            canvasGroup.DOFade(0, fadeDuration).onComplete += () => { rootPanel.Disable(); };
        }

        private void OnDisable()
        {
            canvasGroup.alpha = 0;
            rootPanel.Disable();
        }
    }
}
using System;
using System.Threading.Tasks;
using DG.Tweening;
using SpaceMarket.Core.Scipts.UI;
using SpaceMarket.Core.Scripts.Extensions;
using UnityEngine;

namespace Core.Scripts
{
    [RequireComponent(typeof(CanvasGroup))]
    public class WindowFadeAnimation : MonoBehaviour, IWindowAnimation
    {
        [SerializeField] private float duration;

        private CanvasGroup _canvasGroup;

        private void Start()
        {
            if(!TryGetComponent(out _canvasGroup))
                throw new NullReferenceException($"Cant find component of type CanvasGroup on {name}");
        }

        public async Task PlayShowAnimation()
        {
            gameObject.Enable();
            _canvasGroup.alpha = 0;
            await _canvasGroup.DOFade(1, duration).AsyncWaitForCompletion();
        }

        public async Task PlayHideAnimation()
        {
            _canvasGroup.alpha = 1;
            await _canvasGroup.DOFade(0, duration).AsyncWaitForCompletion();
        }
    }
}
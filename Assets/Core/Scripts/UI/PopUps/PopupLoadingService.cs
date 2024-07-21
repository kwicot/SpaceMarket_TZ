using System;
using DG.Tweening;
using SpaceMarket.Core.Scipts.UI;
using SpaceMarket.Core.Scripts.Extensions;
using UnityEngine;
using Zenject;

namespace SpaceMarket.Core.Scripts.Popup.UI
{
    public class PopupLoadingService : MonoBehaviour, IPopupService
    {
        [SerializeField] private GameObject rootPanel;

        private IWindowAnimation[] _animations;

        private void Awake()
        {
            _animations = GetComponentsInChildren<IWindowAnimation>();
        }

        public void Show()
        {
            rootPanel.Enable();
            foreach (var windowAnimation in _animations)
            {
                windowAnimation.PlayShowAnimation();
            }
        }

        public void Close()
        {
            foreach (var windowAnimation in _animations)
            {
                windowAnimation.PlayHideAnimation();
            }
        }
    }
}
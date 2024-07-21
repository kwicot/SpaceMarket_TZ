using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task Show()
        {
            rootPanel.Enable();

            List<Task> tasks = new List<Task>();
            foreach (var windowAnimation in _animations)
            {
                tasks.Add(windowAnimation.PlayShowAnimation());
            }
            
            await Task.WhenAll(tasks);
        }

        public async Task Hide()
        {
            List<Task> tasks = new List<Task>();
            foreach (var windowAnimation in _animations)
            {
                tasks.Add(windowAnimation.PlayHideAnimation());
            }
            
            await Task.WhenAll(tasks);
            rootPanel.Disable();
        }
    }
}
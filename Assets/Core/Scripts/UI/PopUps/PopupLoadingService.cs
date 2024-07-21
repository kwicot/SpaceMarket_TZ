using System.Collections.Generic;
using System.Threading.Tasks;
using SpaceMarket.Core.Scipts.UI;
using SpaceMarket.Core.Scripts.Extensions;
using UnityEngine;

namespace SpaceMarket.Core.Scripts.Popup.UI
{
    public class PopupLoadingService : MonoBehaviour, IPopupService
    {
        [SerializeField] private GameObject rootPanel;

        private IWindowAnimation[] _animations;
        
        public bool IsShowing { get; private set; }

        private void Awake()
        {
            _animations = GetComponentsInChildren<IWindowAnimation>();
        }

        public async Task Show(int delayMs = 0)
        {
            IsShowing = true;
            await Task.Delay(delayMs);
            
            rootPanel.Enable();

            List<Task> tasks = new List<Task>();
            foreach (var windowAnimation in _animations)
            {
                tasks.Add(windowAnimation.PlayShowAnimation());
            }
            
            await Task.WhenAll(tasks);
        }

        public async Task Hide(int delayMs = 0)
        {
            await Task.Delay(delayMs);

            List<Task> tasks = new List<Task>();
            foreach (var windowAnimation in _animations)
            {
                tasks.Add(windowAnimation.PlayHideAnimation());
            }
            
            await Task.WhenAll(tasks);
            rootPanel.Disable();
            IsShowing = false;
        }
    }
}
using SpaceMarket.Core.Scipts.Extensions;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace SpaceMarket.Core.Scipts.UI
{
    public class GameMenuWindow : Window
    {
        [SerializeField] private Button returnToMenuButton;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button backgroundButton;

        [Inject] private LevelService _levelService;

        protected override void OnStart()
        {
            returnToMenuButton.RemoveAllListeners();
            returnToMenuButton.AddListener(ReturnToMenu);
            
            continueButton.RemoveAllListeners();
            continueButton.AddListener(Continue);
            
            backgroundButton.RemoveAllListeners();
            backgroundButton.AddListener(ReturnToMenu);
        }

        protected override void OnShow()
        {
            
        }

        protected override void OnHide()
        {
            
        }

        private void ReturnToMenu()
        {
            _levelService.ReturnToMenu();
        }

        private void Continue()
        {
            Hide();
        }
    }
}
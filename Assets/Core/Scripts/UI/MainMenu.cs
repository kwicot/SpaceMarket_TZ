using SpaceMarket.Core.Scipts.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SpaceMarket.Core.Scipts.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private SceneReference gameScene;


        private void Start()
        {
            playButton.RemoveAllListeners();
            playButton.AddListener(Play);
            
            exitButton.RemoveAllListeners();
            exitButton.AddListener(Exit);
        }


        public void Play()
        {
            SceneManager.LoadSceneAsync(gameScene);
        }

        public void Exit()
        {
            Application.Quit();
        }
}
}
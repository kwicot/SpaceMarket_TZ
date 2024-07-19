using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Scripts
{
    public class AppService : MonoBehaviour
    {
        [SerializeField] private SceneReference menuScene;
        
        private void Start()
        {
            //TODO wait needed loadings
            SceneManager.LoadScene(menuScene);
        }
    }
}
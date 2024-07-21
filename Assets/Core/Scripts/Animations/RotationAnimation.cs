using UnityEngine;
using Zenject;

namespace SpaceMarket.Core.Scripts.Animations
{
    public class RotationAnimation : MonoBehaviour
    {
        [SerializeField] private Vector3 rotationAxis;
        
        [Inject] private LevelService _levelService;


        private void FixedUpdate()
        {
            if (_levelService.IsPlaying)
            {
                transform.Rotate(rotationAxis * Time.fixedDeltaTime);
            }
        }
    }
}

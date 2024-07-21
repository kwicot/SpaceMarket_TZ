using System;
using DG.Tweening;
using UnityEngine;
using Zenject;
using Sequence = DG.Tweening.Sequence;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SpaceMarket.Core.Scripts.Animations
{
    public class LinerMovingAnimation : MonoBehaviour
    {
        [SerializeField] private Vector3 firstLocalPoint;
        [SerializeField] private Vector3 secondLocalPoint;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float moveInterval;
        [SerializeField] private Ease ease;

        [Inject] private LevelService _levelService;

        private Sequence _sequence;

        private void Start()
        {
            _levelService.OnPlayingStateChanged += OnLevelStateChange;
            
            transform.localPosition = secondLocalPoint;
            _sequence = DOTween.Sequence();
            _sequence.Pause();
            
            _sequence.Append(transform.DOLocalMove(firstLocalPoint, moveSpeed).SetEase(ease));
            _sequence.AppendInterval(moveInterval);
            
            _sequence.Append(transform.DOLocalMove(secondLocalPoint, moveSpeed).SetEase(ease));
            _sequence.AppendInterval(moveInterval);
            
            _sequence.SetLoops(-1);

            if (_levelService.IsPlaying)
                _sequence.Play();
        }

        private void OnLevelStateChange()
        {
            if (_levelService.IsPlaying)
                _sequence.Play();
            else
                _sequence.Pause();
        }

        private void OnEnable()
        {
            if (_levelService.IsPlaying)
                _sequence.Play();
        }

        private void OnDestroy()
        {
            _sequence.Kill();
            _levelService.OnPlayingStateChanged -= OnLevelStateChange;
        }

        private void OnDisable()
        {
            _sequence.Pause();
        }

#if UNITY_EDITOR

        [CustomEditor(typeof(LinerMovingAnimation))]
        class LinerMoverEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();

                LinerMovingAnimation linerObstacle = (LinerMovingAnimation)target;

                if (GUILayout.Button("Set first point"))
                    linerObstacle.firstLocalPoint = Selection.activeGameObject.transform.position;
                
                if (GUILayout.Button("Set second point"))
                    linerObstacle.secondLocalPoint = Selection.activeGameObject.transform.position;

                if (GUILayout.Button("Mirror points"))
                    (linerObstacle.firstLocalPoint, linerObstacle.secondLocalPoint) = (linerObstacle.secondLocalPoint, linerObstacle.firstLocalPoint);

                if (GUILayout.Button("Move to first point"))
                    Selection.activeGameObject.transform.position = linerObstacle.firstLocalPoint;
                
                if (GUILayout.Button("Move to second point"))
                    Selection.activeGameObject.transform.position = linerObstacle.secondLocalPoint;
            }
        }
#endif

    }
}

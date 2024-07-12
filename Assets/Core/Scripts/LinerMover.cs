using DG.Tweening;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SpaceMarket.Core.Scipts.Obstacles
{
    public class LinerMover : MonoBehaviour
    {
        [SerializeField] private Vector3 firstLocalPoint;
        [SerializeField] private Vector3 secondLocalPoint;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float moveInterval;
        [SerializeField] private Ease ease;

        private Sequence _sequence;
        
        private void OnEnable()
        {
            transform.localPosition = secondLocalPoint;
            _sequence = DOTween.Sequence();
            
            _sequence.Append(transform.DOLocalMove(firstLocalPoint, moveSpeed).SetEase(ease));
            _sequence.AppendInterval(moveInterval);
            
            _sequence.Append(transform.DOLocalMove(secondLocalPoint, moveSpeed).SetEase(ease));
            _sequence.AppendInterval(moveInterval);
            
            _sequence.SetLoops(-1);
        }

        private void OnDestroy()
        {
            _sequence.Kill();
        }

        private void OnDisable()
        {
            _sequence.Kill();
        }

#if UNITY_EDITOR

        [CustomEditor(typeof(LinerMover))]
        class LinerMoverEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();

                LinerMover linerObstacle = (LinerMover)target;

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

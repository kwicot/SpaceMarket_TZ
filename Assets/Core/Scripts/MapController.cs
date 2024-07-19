using System;
using System.Collections.Generic;
using ToolBox.Pools;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace SpaceMarket.Core.Scripts.Obstacles
{
    public class MapController : MonoBehaviour
    {
        [FormerlySerializedAs("levelManager")] [SerializeField] private LevelService levelService;
        [SerializeField] private GameObject[] platformPrefabs;
        [SerializeField] private GameObject freePlatformPrefab;
        [SerializeField] private int freePlatformsCount;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float minPositionZ;
        [SerializeField] private float maxPositionZ;
        [SerializeField] private int poolCount;
        [SerializeField] private int platformViewCount;
        [SerializeField] private float platformSize;

        private List<Rigidbody> _platforms;

        private Vector3 _spawnPosition;

        private float _spawnOffset;
        
        private void Start()
        {
            foreach (var platformPrefab in platformPrefabs)
                platformPrefab.Populate(poolCount);

            _spawnPosition = new Vector3(0, 0, minPositionZ);
            playerTransform.position = _spawnPosition;
            _spawnOffset = platformSize * (platformViewCount - 1);

            _platforms = new List<Rigidbody>();
            
            SpawnFirstPlatforms();
        }

        private void FixedUpdate()
        {
            Debug.Log(levelService.name);
            if (levelService.IsPlaying)
            {
                var playerPositionZ = playerTransform.position.z;
                var diff = Mathf.Abs(playerPositionZ - _spawnPosition.z);
                if ( diff < _spawnOffset)
                {
                    DeactivateLastPlatform();
                    SpawnNewRandomPlatform();
                }

                if (playerPositionZ > maxPositionZ)
                {
                    _spawnPosition.z -= minPositionZ;
                    MoveAllToMin();
                }
            }
        }

        void SpawnFirstPlatforms()
        {
            for (int i = 0; i < platformViewCount; i++)
            {
                if(i< freePlatformsCount)
                    SpawnNewPlatform(freePlatformPrefab);
                else
                    SpawnNewRandomPlatform();
            }
        }

        void SpawnNewRandomPlatform()
        {
            var r = Random.Range(0, platformPrefabs.Length);
            SpawnNewPlatform(platformPrefabs[r]);
        }

        void SpawnNewPlatform(GameObject prefab)
        {
            var position = _spawnPosition;
            _spawnPosition.z += platformSize;
            
            var body = GetBody(prefab,position);
            _platforms.Add(body);
        }

        private void DeactivateLastPlatform()
        {
            _platforms[0].gameObject.Release();
            _platforms.RemoveAt(0);
        }

        void MoveAllToMin()
        {
            foreach (var platform in _platforms)
            {
                MoveToMin(platform.transform);
            }
            MoveToMin(playerTransform);
        }

        void MoveToMin(Transform transform)
        {
            var newPos = transform.position;
            newPos.z -= minPositionZ;
            transform.position = newPos;
        }

        Rigidbody GetRandomBody(Vector3 position)
        {
            int r = Random.Range(0, platformPrefabs.Length);
            var prefab = platformPrefabs[r];
            return GetBody(prefab, position);
        }

        Rigidbody GetBody(GameObject prefab, Vector3 position)
        {
            var body = prefab.Reuse(position, Quaternion.identity,this.transform);
            body.SetActive(true);
            return body.GetComponent<Rigidbody>();
        }
        
        
        
    }
}
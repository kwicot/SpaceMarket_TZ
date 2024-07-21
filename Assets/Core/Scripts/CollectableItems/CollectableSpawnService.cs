using System;
using System.Collections.Generic;
using SpaceMarket.Core.Scripts.Extensions;
using ToolBox.Pools;
using UnityEngine;
using Random = System.Random;

namespace Core.Scripts.Collectable
{
    public class CollectableSpawnService : MonoBehaviour
    {
        [SerializeField] private CollectableSpawnData[] spawnData;

        private List<int> _randomList;
        private Random _random;

        private bool _initialized = false;

        private void Start()
        {
            if(!_initialized)
                Initialize();
        }

        void Initialize()
        {
            _random = new Random((int)DateTime.Now.TimeOfDay.TotalMilliseconds);
            Randomize();
            GeneratePool();
            _initialized = true;
        }

        private void GeneratePool()
        {
            foreach (var data in spawnData)
            {
                data.Prefab.Populate(10);
            }
        }

        /// <summary>
        /// Далеко не самий найкращий спосіб рандомних вагів, дла прототипу підійде
        /// </summary>
        private void Randomize()
        {
            _randomList = new List<int>();
            for (int i = 0; i < spawnData.Length; i++)
            {
                var data = spawnData[i];
                for (int j = 0; j < data.Chance; j++)
                {
                    _randomList.Add(i);
                }
            }
            
            _randomList.Shuffle();
        }
        
        public GameObject GetRandom()
        {
            if(!_initialized)
                Initialize();
            
            int r = _random.Next(0, _randomList.Count);
            int index = _randomList[r];

            return spawnData[index].Prefab;
        }
    }
}
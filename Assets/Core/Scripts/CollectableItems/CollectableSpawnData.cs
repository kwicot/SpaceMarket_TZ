using System;
using UnityEngine;

namespace Core.Scripts.Collectable
{
    [Serializable]
    public class CollectableSpawnData
    {
        //TODO inspector naming change from 'element 0,1,2... to name of prefab
        
        [SerializeField] private GameObject prefab;
        [SerializeField][Range(0,100)] private int chance;

        public GameObject Prefab => prefab;
        public int Chance => chance;
    }
}
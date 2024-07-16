using System;
using UnityEngine;

namespace Core.Scripts.Collectable
{
    [Serializable]
    public class CollectableSpawnData
    {
        [SerializeField] private GameObject prefab;
        [SerializeField][Range(0,100)] private int chance;

        public GameObject Prefab => prefab;
        public int Chance => chance;
    }
}
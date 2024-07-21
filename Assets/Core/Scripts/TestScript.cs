using System;
using Core.Scripts.Geo;
using UnityEngine;

namespace Core.Scripts
{
    public class TestScript : MonoBehaviour
    {
        private void Start()
        {
            GeoManager.GetCountry();
        }
    }
}
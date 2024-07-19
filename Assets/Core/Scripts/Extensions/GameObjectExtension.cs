using SpaceMarket.Core.Scipts.UI;
using UnityEngine;

namespace SpaceMarket.Core.Scipts.Extensions
{
    public static class GameObjectExtension
    {
        public static void Disable(this GameObject gameObject)
        {
            gameObject?.SetActive(false);
        }

        public static void Enable(this GameObject gameObject)
        {
            gameObject?.SetActive(true);
        }
    }
}
﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SpaceMarket.Core.Scipts.Extensions
{
    public static class ButtonExtension
    {
        public static Button RemoveAllListeners(this Button button)
        {
            if(button != null)
                button.onClick.RemoveAllListeners();
            else
                Debug.LogWarning("Try remove all listeners from null button");

            return button;
        }

        public static Button AddListener(this Button button, UnityAction action)
        {
            if (button != null)
                button.onClick.AddListener(action);
            else
                Debug.LogWarning("Try add listener to null button");

            return button;
        }

        public static Button RemoveListener(this Button button, UnityAction action)
        {
            if (button != null)
                button.onClick.RemoveListener(action);
            else
                Debug.LogWarning("Try remove listener from null button");

            return button;
        }
    }
}
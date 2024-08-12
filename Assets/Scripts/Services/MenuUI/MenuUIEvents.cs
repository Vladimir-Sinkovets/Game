using System;
using UnityEngine;

namespace Assets.Scripts.Services.MenuUI
{
    public class MenuUIEvents : MonoBehaviour, IMenuUIEvents
    {
        public event Action OnStartButtonClicked;

        public void StartButton()
        {
            OnStartButtonClicked?.Invoke();
        }
    }
}

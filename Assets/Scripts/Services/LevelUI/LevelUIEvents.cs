using System;
using UnityEngine;

namespace Assets.Scripts.Services.LevelUI
{
    public class LevelUIEvents : MonoBehaviour, ILevelUIEvents
    {
        public event Action OnMenuButtonClick;

        public void MenuClickHandler()
        {
            OnMenuButtonClick?.Invoke();
        }
    }
}

using Assets.Scripts.Services.MenuUI;
using Assets.Scripts.Services.SceneManagement;
using System;
using Zenject;

namespace Assets.Scripts.SceneMains
{
    public class MenuMain : IInitializable, IDisposable
    {
        private readonly ILevelLoader _levelLoader;
        private readonly IMenuUIEvents _menuUIEvents;

        public MenuMain(ILevelLoader levelLoader, IMenuUIEvents menuUIEvents)
        {
            _levelLoader = levelLoader;
            _menuUIEvents = menuUIEvents;
        }

        public void Initialize()
        {
            _menuUIEvents.OnStartButtonClicked += _levelLoader.LoadLevel;
        }

        public void Dispose()
        {
            _menuUIEvents.OnStartButtonClicked -= _levelLoader.LoadLevel;
        }
    }
}

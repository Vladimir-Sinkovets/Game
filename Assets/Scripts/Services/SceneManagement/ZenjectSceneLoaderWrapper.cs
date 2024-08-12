using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Scripts.Services.SceneManagement
{
    public class ZenjectSceneLoaderWrapper
    {
        private readonly ZenjectSceneLoader _loader;

        public ZenjectSceneLoaderWrapper(ZenjectSceneLoader loader)
        {
            _loader = loader;
        }

        public void Load(int sceneId, Action<DiContainer> action = null)
            => _loader.LoadScene(sceneId, LoadSceneMode.Single, (container) => action?.Invoke(container));
    }
}

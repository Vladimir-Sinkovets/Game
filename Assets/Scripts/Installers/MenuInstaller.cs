using Assets.Scripts.SceneMains;
using Assets.Scripts.Services.MenuUI;
using Assets.Scripts.Services.SceneManagement;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class MenuInstaller : MonoInstaller
    {
        [SerializeField] private MenuUIEvents _menuUIEvents;

        public override void InstallBindings()
        {
            Container.Bind<ILevelLoader>()
                .To<SceneManager>()
                .AsTransient();

            Container.Bind<IMenuUIEvents>()
                .To<MenuUIEvents>()
                .FromInstance(_menuUIEvents);

            Container.BindInterfacesAndSelfTo<MenuMain>()
                .AsSingle();
        }
    }
}
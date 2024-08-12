using Assets.Scripts.Services.SceneManagement;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ZenjectSceneLoaderWrapper>()
                .AsTransient();
        }
    }
}

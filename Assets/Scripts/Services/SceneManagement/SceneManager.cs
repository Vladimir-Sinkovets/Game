namespace Assets.Scripts.Services.SceneManagement
{
    public class SceneManager : ILevelLoader, IMenuLoader
    {
        private readonly ZenjectSceneLoaderWrapper _wrapper;

        public SceneManager(ZenjectSceneLoaderWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public void LoadLevel()
        {
            _wrapper.Load((int)SceneId.Level);
        }

        public void LoadMenu()
        {
            _wrapper.Load((int)SceneId.Menu);
        }
    }
}

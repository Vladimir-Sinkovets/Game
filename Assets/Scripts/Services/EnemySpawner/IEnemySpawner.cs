using Assets.Scripts.Settings;

namespace Assets.Scripts.Services.EnemySpawner
{
    public interface IEnemySpawner
    {
        void SetLevel(LevelSettings settings, int levelIndex);
    }
}
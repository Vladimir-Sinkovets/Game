using Assets.Scripts.Services.Controller;
using Assets.Scripts.Services.EnemySpawner;
using Assets.Scripts.Settings;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private SpawnerSettings _spawnerSettings;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private EnemiesController _enemiesController;

    public override void InstallBindings()
    {
        Container.Bind<FixedJoystick>()
            .FromInstance(_joystick);

        Container.BindInterfacesTo<EnemySpawner>()
            .FromInstance(_enemySpawner);

        Container.Bind<SpawnerSettings>()
            .FromInstance(_spawnerSettings);

        Container.Bind<IEnemiesController>()
            .To<EnemiesController>()
            .FromInstance(_enemiesController);
    }
}

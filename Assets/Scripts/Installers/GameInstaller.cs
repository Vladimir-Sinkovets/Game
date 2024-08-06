using Assets.Scripts.Factories.ProjectileFactories;
using Assets.Scripts.PlayerComponents;
using Assets.Scripts.Services.Controllers;
using Assets.Scripts.Services.EnemyAccessor;
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
    [SerializeField] private Player _player;
    [SerializeField] private ProjectileFactory _projectileFactory;

    public override void InstallBindings()
    {
        Container.Bind<FixedJoystick>()
            .FromInstance(_joystick);

        Container.BindInterfacesTo<EnemySpawner>()
            .FromInstance(_enemySpawner);

        Container.Bind<SpawnerSettings>()
            .FromInstance(_spawnerSettings);
        
        Container.Bind<ProjectileFactory>()
            .FromInstance(_projectileFactory);

        Container.Bind<IEnemiesController>()
            .To<EnemiesController>()
            .FromInstance(_enemiesController);

        Container.Bind<IEnemyStorage>()
            .To<EnemyStorage>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<Player>()
            .FromInstance(_player);
    }
}

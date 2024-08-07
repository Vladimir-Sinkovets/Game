using Assets.Scripts;
using Assets.Scripts.Factories.ProjectileFactories;
using Assets.Scripts.PlayerComponents;
using Assets.Scripts.Services.EnemyEvents;
using Assets.Scripts.Services.EnemySpawner;
using Assets.Scripts.Services.PlayerLevelsManager;
using Assets.Scripts.Settings;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private GameSettings _spawnerSettings;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Player _player;
    [SerializeField] private ProjectileFactory _projectileFactory;

    public override void InstallBindings()
    {
        Container.Bind<FixedJoystick>()
            .FromInstance(_joystick);

        Container.BindInterfacesTo<EnemySpawner>()
            .FromInstance(_enemySpawner);

        Container.Bind<GameSettings>()
            .FromInstance(_spawnerSettings);
        
        Container.Bind<ProjectileFactory>()
            .FromInstance(_projectileFactory);

        Container.BindInterfacesAndSelfTo<Player>()
            .FromInstance(_player);

        Container.BindInterfacesAndSelfTo<LevelsManager>()
            .AsSingle();

        Container.Bind<IEnemyEventBus>()
            .To<EnemyEventBus>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<LevelMain>()
            .AsSingle();
    }
}

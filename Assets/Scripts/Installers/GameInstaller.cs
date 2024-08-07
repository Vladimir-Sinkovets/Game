using Assets.Scripts;
using Assets.Scripts.Factories.ProjectileFactories;
using Assets.Scripts.PlayerComponents;
using Assets.Scripts.PlayerComponents.AbilitySettings;
using Assets.Scripts.Services.EnemyEvents;
using Assets.Scripts.Services.EnemySpawner;
using Assets.Scripts.Services.PlayerLevelsManager;
using Assets.Scripts.Settings;
using Assets.Scripts.UI.LevelCounter;
using Assets.Scripts.UI.Progress;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private GameSettings _spawnerSettings;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Player _player;
    [SerializeField] private DefaultAttackSettings _defaultAttackSettings;
    [SerializeField] private ProgressUI _progress;
    [SerializeField] private LevelCounterUI _levelCounter;

    public override void InstallBindings()
    {
        Container.Bind<FixedJoystick>()
            .FromInstance(_joystick);

        Container.BindInterfacesTo<EnemySpawner>()
            .FromInstance(_enemySpawner);

        Container.Bind<GameSettings>()
            .FromInstance(_spawnerSettings);

        Container.Bind<DefaultAttackSettings>()
            .FromInstance(_defaultAttackSettings);

        Container.BindInterfacesTo<ProgressUI>()
            .FromInstance(_progress);

        Container.BindInterfacesTo<LevelCounterUI>()
            .FromInstance(_levelCounter);

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

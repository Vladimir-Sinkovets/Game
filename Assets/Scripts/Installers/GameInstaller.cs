using Assets.Scripts;
using Assets.Scripts.PlayerComponents;
using Assets.Scripts.PlayerComponents.AbilitySettings;
using Assets.Scripts.Services.EnemyEvents;
using Assets.Scripts.Services.EnemySpawner;
using Assets.Scripts.Services.PlayerLevelsManager;
using Assets.Scripts.Settings;
using Assets.Scripts.UI.AbilityPanel;
using Assets.Scripts.UI.LevelCounter;
using Assets.Scripts.UI.Progress;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Player _player;
    [SerializeField] private ProgressUI _progress;
    [SerializeField] private LevelCounterUI _levelCounter;
    [SerializeField] private AbilityPanelUI _panel;
    [Space]
    [SerializeField] private GameSettings _spawnerSettings;
    [SerializeField] private DefaultAttackSettings _defaultAttackSettings;
    [SerializeField] private RotatingAxesSettings _axesSettings;

    public override void InstallBindings()
    {
        BindServices();

        BindMain();

        BindSettings();

        BindUI();
    }

    private void BindMain()
    {
        Container.BindInterfacesAndSelfTo<LevelMain>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<Player>()
            .FromInstance(_player);
    }

    private void BindServices()
    {
        Container.BindInterfacesTo<EnemySpawner>()
            .FromInstance(_enemySpawner);

        Container.BindInterfacesAndSelfTo<LevelsManager>()
            .AsSingle();

        Container.Bind<IEnemyEventBus>()
            .To<EnemyEventBus>()
            .AsSingle();
    }

    private void BindSettings()
    {
        Container.Bind<GameSettings>()
            .FromInstance(_spawnerSettings);

        Container.Bind<DefaultAttackSettings>()
            .FromInstance(_defaultAttackSettings);

        Container.Bind<RotatingAxesSettings>()
            .FromInstance(_axesSettings);
    }

    private void BindUI()
    {
        Container.BindInterfacesAndSelfTo<AbilityPanelUI>()
            .FromInstance(_panel);

        Container.Bind<FixedJoystick>()
            .FromInstance(_joystick);

        Container.BindInterfacesTo<ProgressUI>()
            .FromInstance(_progress);

        Container.BindInterfacesTo<LevelCounterUI>()
            .FromInstance(_levelCounter);
    }
}

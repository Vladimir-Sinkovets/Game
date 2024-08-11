using Assets.Scripts;
using Assets.Scripts.PlayerComponents;
using Assets.Scripts.Services.EnemyEvents;
using Assets.Scripts.Services.EnemySpawner;
using Assets.Scripts.Services.PlayerLevelsManager;
using Assets.Scripts.Services.UI.AbilityPanel;
using Assets.Scripts.Services.UI.LevelCounter;
using Assets.Scripts.Services.UI.Progress;
using Assets.Scripts.Settings;
using Assets.Scripts.Settings.AbilitySettings;
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
        Container.Bind<IAbilityPanelUI>()
            .To<AbilityPanelUI>()
            .FromInstance(_panel);

        Container.Bind<FixedJoystick>()
            .FromInstance(_joystick);

        Container.BindInterfacesTo<ProgressUI>()
            .FromInstance(_progress);

        Container.Bind<ILevelCounterUI>()
            .To<LevelCounterUI>()
            .FromInstance(_levelCounter);
    }
}

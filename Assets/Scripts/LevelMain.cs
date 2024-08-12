using Assets.Scripts.PlayerComponents;
using Assets.Scripts.Services.EnemySpawner;
using Assets.Scripts.Services.PlayerLevelsManager;
using Assets.Scripts.Services.UI.AbilityPanel;
using Assets.Scripts.Services.UI.EndingPanel;
using Assets.Scripts.Services.UI.LevelCounter;
using Assets.Scripts.Services.UI.Progress;
using Assets.Scripts.Settings;
using DG.Tweening;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class LevelMain : IInitializable, IDisposable
    {
        [Inject] private readonly ILevelManager _levelManager;
        [Inject] private readonly IEnemySpawner _enemySpawner;
        [Inject] private readonly ILevelCounterUI _levelCounterUI;
        [Inject] private readonly IAbilityPanelUI _panel;
        [Inject] private readonly IEndingPanelUI _endingPanel;
        [Inject] private readonly Player _player;
        [Inject(Id = BarId.Progress)] private readonly IBarUI _progress;
        [Inject(Id = BarId.Hp)] private readonly IBarUI _hpBar;


        public void Initialize()
        {
            _player.Health.OnHpChanged += _hpBar.SetValue;

            _player.Health.OnHpEnded += OnPlayerDiedHandler;

            _player.Init();

            _levelManager.OnLevelChanged += _enemySpawner.SetLevel;

            _levelManager.OnExperienceChanged += _progress.SetValue;

            _levelManager.OnLevelChanged += _levelCounterUI.ChangeLevelTextCount;

            _levelManager.OnLevelChanged += ShowPanel;

            _levelManager.Init();

            _panel.OnSkillUpgraded += HidePanel;

            _panel.Init();
        }

        private void OnPlayerDiedHandler()
        {
            Time.timeScale = 0;

            _endingPanel.Show();
        }

        private void ShowPanel(LevelSettings settings, int level)
        {
            if (level == 0)
                return;

            Time.timeScale = 0;

            _panel.Show();
        }

        private void HidePanel()
        {
            Time.timeScale = 1;

            _panel.Hide();
        }

        public void Dispose()
        {
            _player.Health.OnHpChanged -= _hpBar.SetValue;

            _player.Health.OnHpEnded -= OnPlayerDiedHandler;

            _levelManager.OnLevelChanged -= _enemySpawner.SetLevel;

            _levelManager.OnExperienceChanged -= _progress.SetValue;

            _levelManager.OnLevelChanged -= _levelCounterUI.ChangeLevelTextCount;

            _levelManager.OnLevelChanged -= ShowPanel;

            _panel.OnSkillUpgraded += HidePanel;
        }
    }
}

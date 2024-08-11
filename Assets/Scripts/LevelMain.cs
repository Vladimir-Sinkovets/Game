using Assets.Scripts.Services.EnemySpawner;
using Assets.Scripts.Services.PlayerLevelsManager;
using Assets.Scripts.Services.UI.AbilityPanel;
using Assets.Scripts.Services.UI.LevelCounter;
using Assets.Scripts.Services.UI.Progress;
using Assets.Scripts.Settings;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class LevelMain : IInitializable, IDisposable
    {
        [Inject] private readonly ILevelManager _levelManager;
        [Inject] private readonly IEnemySpawner _enemySpawner;
        [Inject] private readonly IProgressUI _progress;
        [Inject] private readonly ILevelCounterUI _levelCounterUI;
        [Inject] private readonly AbilityPanelUI _panel;


        public void Initialize()
        {
            _levelManager.OnLevelChanged += _enemySpawner.SetLevel;

            _levelManager.OnExperienceChanged += _progress.SetValue;

            _levelManager.OnLevelChanged += _levelCounterUI.ChangeLevelTextCount;

            _levelManager.Init();

            _levelManager.OnLevelChanged += ShowPanel;

            _panel.OnSkillUpgraded += HidePanel;
        }

        private void ShowPanel(LevelSettings settings, int level)
        {
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
            _levelManager.OnLevelChanged -= _enemySpawner.SetLevel;

            _levelManager.OnExperienceChanged -= _progress.SetValue;

            _levelManager.OnLevelChanged -= _levelCounterUI.ChangeLevelTextCount;

            _levelManager.OnLevelChanged -= ShowPanel;

            _panel.OnSkillUpgraded += HidePanel;
        }
    }
}

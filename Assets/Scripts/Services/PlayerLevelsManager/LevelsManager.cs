using Assets.Scripts.Enemies;
using Assets.Scripts.Factories.EnemyFactories;
using Assets.Scripts.Services.EnemyEvents;
using Assets.Scripts.Settings;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Services.PlayerLevelsManager
{
    public class LevelsManager : IDisposable, ILevelManager
    {
        public event Action<int> OnExperienceChanged;
        public event Action<LevelSettings> OnLevelChanged;

        private readonly IEnemyEventBus _enemyEvent;
        private readonly GameSettings _settings;


        private int _experience = 0;
        private int _currentLevel = 0;

        public int CurrentLevel
        {
            get => _currentLevel; set
            {
                _currentLevel = value;

                OnLevelChanged?.Invoke(CurrentLevelSettings);
            }
        }

        private int Experience
        {
            get => _experience;
            set
            {
                _experience = value;
                OnExperienceChanged?.Invoke(value);

                if (CurrentLevel == _settings.LevelSettings.Count - 1)
                    return;

                if (_experience >= NextLevelSettings.ExperienceRequired)
                {
                    CurrentLevel++;
                }
            }
        }

        public LevelsManager(IEnemyEventBus enemyEvent, GameSettings settings)
        {
            _enemyEvent = enemyEvent;
            _enemyEvent.OnEnemyDied += OnEnemyDiedHandler;

            _settings = settings;
        }

        public void Dispose()
        {
            _enemyEvent.OnEnemyDied -= OnEnemyDiedHandler;
        }

        private void OnEnemyDiedHandler(Enemy enemy)
        {
            Experience += enemy.Experience;

            Debug.Log("_experience = " + Experience);
        }

        public void Init()
        {
            CurrentLevel = 0;
        }

        private LevelSettings CurrentLevelSettings =>_settings.LevelSettings[CurrentLevel];
        private LevelSettings NextLevelSettings =>_settings.LevelSettings[CurrentLevel + 1];
    }
}

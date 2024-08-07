using Assets.Scripts.Enemies;
using Assets.Scripts.Factories.EnemyFactories;
using Assets.Scripts.Services.EnemyEvents;
using Assets.Scripts.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Services.PlayerLevelsManager
{
    public class LevelsManager : IDisposable, ILevelManager
    {
        public event Action<int, int> OnExperienceChanged;
        public event Action<LevelSettings, int> OnLevelChanged;

        private readonly IEnemyEventBus _enemyEvent;
        private readonly GameSettings _settings;


        private int _experience;
        private int _currentLevel;

        public int CurrentLevel
        {
            get => _currentLevel;
            set
            {
                _currentLevel = value;

                OnLevelChanged?.Invoke(CurrentLevelSettings, _currentLevel);
            }
        }
        public int MaxLevel { get => _settings.LevelSettings.Count - 1; }

        private int Experience
        {
            get => _experience;
            set
            {
                _experience = value;
                
                var goal = GetExperienceGoal();

                if (_experience >= goal && CurrentLevel < MaxLevel)
                {
                    CurrentLevel++;

                    _experience = 0;

                    goal = GetExperienceGoal();
                }

                OnExperienceChanged?.Invoke(_experience, goal);
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
            Experience = 0;
        }

        private LevelSettings CurrentLevelSettings =>_settings.LevelSettings[CurrentLevel];


        private int GetExperienceGoal()
        {
            if (CurrentLevel >= _settings.LevelSettings.Count - 1)
                return _settings.LevelSettings.Last().ExperienceRequired;

            return _settings.LevelSettings[CurrentLevel + 1].ExperienceRequired;
        }
    }
}

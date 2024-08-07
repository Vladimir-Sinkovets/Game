using Assets.Scripts.Enemies;
using Assets.Scripts.Services.EnemyEvents;
using System;
using UnityEngine;

namespace Assets.Scripts.Services.PlayerExPointsStorage
{
    public class ExperienceCounter : IDisposable
    {
        public event Action<int> OnExperienceChanged;

        private readonly IEnemyEventBus _enemyEvent;

        private int _experience;

        private int Experience
        {
            get => _experience;
            set
            {
                _experience = value;
                OnExperienceChanged?.Invoke(value);
            }
        }

        public ExperienceCounter(IEnemyEventBus enemyEvent)
        {
            _enemyEvent = enemyEvent;
            _enemyEvent.OnEnemyDied += OnEnemyDiedHandler;
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
    }
}

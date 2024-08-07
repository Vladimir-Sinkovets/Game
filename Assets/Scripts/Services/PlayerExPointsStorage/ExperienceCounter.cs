using Assets.Scripts.Enemies;
using Assets.Scripts.Services.EnemyEvents;
using System;
using UnityEngine;

namespace Assets.Scripts.Services.PlayerExPointsStorage
{
    public class ExperienceCounter : IDisposable
    {
        private readonly IEnemyEventBus _enemyEvent;

        private int _experience;

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
            _experience += enemy.Experience;

            Debug.Log("_experience = " + _experience);
        }
    }
}

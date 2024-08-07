using Assets.Scripts.Enemies;
using System;

namespace Assets.Scripts.Services.EnemyEvents
{
    public class EnemyEventBus : IEnemyEventBus
    {
        public event Action<Enemy> OnEnemyDied;

        public void EnemyDied(Enemy enemy) => OnEnemyDied?.Invoke(enemy);
    }
}

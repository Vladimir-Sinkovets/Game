using Assets.Scripts.Enemies;
using System;

namespace Assets.Scripts.Services.EnemyEvents
{
    public interface IEnemyEventBus
    {
        event Action<Enemy> OnEnemyDied;

        void EnemyDied(Enemy enemy);
    }
}
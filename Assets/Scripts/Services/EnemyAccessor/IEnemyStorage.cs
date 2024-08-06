using Assets.Scripts.Enemies;
using System.Collections.Generic;

namespace Assets.Scripts.Services.EnemyAccessor
{
    public interface IEnemyStorage
    {
        IEnumerable<Enemy> Enemies { get; }

        void Add(Enemy enemy);
    }
}
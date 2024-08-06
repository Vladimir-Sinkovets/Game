using Assets.Scripts.Enemies;
using System.Collections.Generic;

namespace Assets.Scripts.Services.EnemyAccessor
{
    public class EnemyStorage : IEnemyStorage
    {
        private readonly List<Enemy> _enemies = new();
        public IEnumerable<Enemy> Enemies => _enemies;
        public void Add(Enemy enemy) => _enemies.Add(enemy);
    }
}

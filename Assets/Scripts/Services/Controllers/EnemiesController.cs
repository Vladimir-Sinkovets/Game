using Assets.Scripts.Enemies;
using Assets.Scripts.PlayerComponents;
using Assets.Scripts.Services.EnemyAccessor;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Services.Controllers
{
    public class EnemiesController : MonoBehaviour, IEnemiesController
    {
        private Transform _target;

        private IEnemyStorage _enemyStorage;

        private IEnumerable<Enemy> Enemies => _enemyStorage.Enemies;

        [Inject]
        private void Construct(IEnemyStorage enemyStorage, Player player)
        {
            _enemyStorage = enemyStorage;
            _target = player.transform;
        }

        private void Update()
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.Move(_target.position);
            }
        }
    }
}

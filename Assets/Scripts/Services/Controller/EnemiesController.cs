using Assets.Scripts.Enemies;
using Assets.Scripts.Services.EnemyAccessor;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Services.Controller
{
    public class EnemiesController : MonoBehaviour, IEnemiesController
    {
        [SerializeField] private Transform _target;

        private IEnemyStorage _enemyStorage;

        private IEnumerable<Enemy> Enemies => _enemyStorage.Enemies;

        [Inject]
        private void Construct(IEnemyStorage enemyStorage)
        {
            _enemyStorage = enemyStorage;
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

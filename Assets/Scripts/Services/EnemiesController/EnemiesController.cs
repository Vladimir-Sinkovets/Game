using Assets.Scripts.Enemies;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Services.EnemiesController
{
    public class EnemiesController : MonoBehaviour
    {
        [SerializeField] private List<Enemy> _enemies;
        [SerializeField] private Transform _target;

        private void Update()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.MoveTo(_target.position);
            }
        }
    }
}

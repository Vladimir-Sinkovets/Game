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
                Move(_target.position, enemy);
            }
        }

        private void Move(Vector3 target, Enemy enemy)
        {
            var direction = target - enemy.transform.position;

            var distance = direction.magnitude;
            
            var normalizedDirection = direction / distance;

            if (distance < 1)
                return;

            enemy.transform.Translate(enemy.Speed * Time.deltaTime * normalizedDirection);
        }
    }
}

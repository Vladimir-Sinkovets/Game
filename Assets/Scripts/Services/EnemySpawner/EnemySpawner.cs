using Assets.Scripts.Enemies;
using Assets.Scripts.Services.EnemyAccessor;
using Assets.Scripts.Settings;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Services.EnemySpawner
{
    public class EnemySpawner : MonoBehaviour, ITickable, IInitializable
    {
        private SpawnerSettings _settings;
        private DiContainer _container;
        private IEnemyStorage _enemyStorage;
        private System.Random _random = new();


        [SerializeField] private Vector2 _firstAngleOfField;
        [SerializeField] private Vector2 _secondAngleOfField;

        private int _currentSpawnLevel = 0;

        private float _spawnTime;
        private float _nextSpawnTime;

        [Inject]
        public void Construct(SpawnerSettings settings, DiContainer container, IEnemyStorage enemyStorage)
        {
            _settings = settings;
            _container = container;
            _enemyStorage = enemyStorage;
        }

        public void Initialize()
        {
            _spawnTime = 1.0f / _settings.SpawnRate;

            _nextSpawnTime = Time.time;
        }

        public void Tick()
        {
            if (_nextSpawnTime <= Time.time)
            {
                SpawnUnit();

                _nextSpawnTime = Time.time + _spawnTime;
            }
        }

        private void SpawnUnit()
        {
            var position = GetRandomPosition();

            Enemy enemy = GetRandomEnemyFromCurrentLevel();

            enemy.transform.position = position;

            _enemyStorage.Add(enemy);
        }

        private Enemy GetRandomEnemyFromCurrentLevel()
        {
            var currentEnemyFactories = _settings.SpawnSettings[_currentSpawnLevel].EnemyFactories;

            var enemyFactoryIndex = _random.Next(currentEnemyFactories.Count);

            return currentEnemyFactories[enemyFactoryIndex].Get(_container);
        }

        private Vector2 GetRandomPosition()
        {
            var x = Random.Range(_firstAngleOfField.x, _secondAngleOfField.x);
            var y = Random.Range(_firstAngleOfField.y, _secondAngleOfField.y);

            return new Vector2(x, y);
        }

        private void OnDrawGizmos()
        {
            var point_1 = _firstAngleOfField;
            var point_3 = _secondAngleOfField;

            var point_2 = new Vector2(point_1.x, point_3.y);
            var point_4 = new Vector2(point_3.x, point_1.y);

            Gizmos.DrawLine(point_1, point_2);
            Gizmos.DrawLine(point_2, point_3);
            Gizmos.DrawLine(point_3, point_4);
            Gizmos.DrawLine(point_4, point_1);
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Settings
{
    [CreateAssetMenu(fileName = "SpawnerSettings", menuName = "Configs/EnemySpawnerSettings")]
    public class SpawnerSettings : ScriptableObject
    {
        [SerializeField] private List<SpawnLevel> _spawnSettings;
        [SerializeField] private int _spawnRate = 2;

        public IList<SpawnLevel> SpawnSettings { get => _spawnSettings; }
        public int SpawnRate { get => _spawnRate; }
    }
}
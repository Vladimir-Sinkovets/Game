using Assets.Scripts.Factories.EnemyFactories;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Settings
{
    [Serializable]
    public class LevelSettings
    {
        [SerializeField] private List<EnemyFactory> _enemyFactories;
        [SerializeField] private int _experienceRequired;
        [SerializeField] private float _spawnRate;

        public IList<EnemyFactory> EnemyFactories { get => _enemyFactories; }
        public int ExperienceRequired { get => _experienceRequired; }
        public float SpawnRate { get => _spawnRate; }
    }
}

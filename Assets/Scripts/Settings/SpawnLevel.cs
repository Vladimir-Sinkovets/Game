using Assets.Scripts.Factories.EnemyFactories;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Settings
{
    [Serializable]
    public class SpawnLevel
    {
        [SerializeField] private List<EnemyFactory> _enemyFactories;

        public IList<EnemyFactory> EnemyFactories { get => _enemyFactories; }
    }
}

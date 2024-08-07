using Assets.Scripts.Services.EnemySpawner;
using Assets.Scripts.Services.PlayerLevelsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts
{
    public class LevelMain : IInitializable
    {
        private readonly ILevelManager _levelManager;
        private readonly IEnemySpawner _enemySpawner;

        public LevelMain(ILevelManager levelManager, IEnemySpawner enemySpawner)
        {
            _levelManager = levelManager;
            _enemySpawner = enemySpawner;
        }

        public void Initialize()
        {
            _levelManager.OnLevelChanged += _enemySpawner.SetLevel;

            _levelManager.Init();
        }
    }
}

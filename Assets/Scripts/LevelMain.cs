using Assets.Scripts.Services.EnemySpawner;
using Assets.Scripts.Services.PlayerLevelsManager;
using Assets.Scripts.UI.LevelCounter;
using Assets.Scripts.UI.Progress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts
{
    public class LevelMain : IInitializable, IDisposable
    {
        private readonly ILevelManager _levelManager;
        private readonly IEnemySpawner _enemySpawner;
        private readonly IProgressUI _progress;
        private readonly ILevelCounterUI _levelCounterUI;

        public LevelMain(ILevelManager levelManager, IEnemySpawner enemySpawner, IProgressUI progressUI, ILevelCounterUI levelCounterUI)
        {
            _levelManager = levelManager;
            _enemySpawner = enemySpawner;
            _progress = progressUI;
            _levelCounterUI = levelCounterUI;
        }

        public void Initialize()
        {
            _levelManager.OnLevelChanged += _enemySpawner.SetLevel;

            _levelManager.OnExperienceChanged += _progress.SetValue;

            _levelManager.OnLevelChanged += _levelCounterUI.ChangeLevelTextCount;

            _levelManager.Init();
        }

        public void Dispose()
        {
            _levelManager.OnLevelChanged -= _enemySpawner.SetLevel;

            _levelManager.OnExperienceChanged -= _progress.SetValue;

            _levelManager.OnLevelChanged -= _levelCounterUI.ChangeLevelTextCount;
        }
    }
}

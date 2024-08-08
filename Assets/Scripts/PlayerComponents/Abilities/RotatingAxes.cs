using Assets.Scripts.Factories.ProjectileFactories;
using Assets.Scripts.PlayerComponents.AbilitySettings;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Assets.Scripts.PlayerComponents.Abilities
{
    public class RotatingAxes : IAbility
    {
        private readonly RotatingAxesSettings _settings;
        private readonly Player _player;
        private int _currentLevel = -1;
        private Axes _axes;

        public RotatingAxes(RotatingAxesSettings settings, Player player)
        {
            _settings = settings;
            _player = player;
        }
        public int Level => _currentLevel;
        public int Damage => CurrentLevelSettings.Damage;
        public int MaxLevel => _settings.Levels.Count - 1;

        public Sprite Sprite => _settings.Icon;

        public void IncreaseLevel()
        {
            _currentLevel++;

            if (_currentLevel == 0)
                _axes.gameObject.SetActive(true);
        }

        public void Init()
        {
            _axes = _settings.GetAxes(_player.transform);

            _axes.Init(this);

            _axes.gameObject.SetActive(false);
        }

        public void Update()
        {
            if (_currentLevel == -1)
                return;

            float rotationAmount = CurrentLevelSettings.RotatingSpeed * Time.deltaTime;

            _axes.transform.Rotate(0, 0, rotationAmount);
        }

        private RotatingAxesLevelSettings CurrentLevelSettings => _settings.Levels[_currentLevel];
    }
}

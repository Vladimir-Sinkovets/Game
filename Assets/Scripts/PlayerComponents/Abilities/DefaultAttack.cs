using Assets.Scripts.Factories.ProjectileFactories;
using Assets.Scripts.PlayerComponents.AbilitySettings;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.PlayerComponents.Abilities
{
    public class DefaultAttack : IAbility
    {
        private readonly DefaultAttackSettings _settings;
        private readonly DiContainer _diContainer;
        private readonly Player _player;

        private float _nextAttackTime;
        private float _timeBetweenAttacks = 1;
        private int _currentLevel = 0;

        public int Level => _currentLevel;
        public int MaxLevel => _settings.Levels.Count - 1;

        public Sprite Sprite => CurrentLevelSettings.Icon;

        public DefaultAttack(DefaultAttackSettings settings, DiContainer diContainer, Player player)
        {
            _settings = settings;
            _diContainer = diContainer;
            _player = player;
        }

        public void IncreaseLevel()
        {
            Debug.Log("level up");
            _currentLevel++;
        }

        public void Update()
        {
            if (_nextAttackTime <= Time.time)
            {
                _nextAttackTime = Time.time + _timeBetweenAttacks;

                Attack();
            }
        }

        private void Attack()
        {
            var target = _player.GetNearestObject();

            if (target == null)
                return;

            var projectile = CurrentFactory.Get(_diContainer);

            projectile.SetDirection(target.transform.position - _player.transform.position);
            projectile.SetPosition(_player.transform.position);
        }

        public void Init() { }

        private ProjectileFactory CurrentFactory => _settings.Levels[_currentLevel].Factory;
        private DefaultAttackLevelSettings CurrentLevelSettings => _settings.Levels[_currentLevel];
    }
}

using Assets.Scripts.Factories.ProjectileFactories;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.PlayerComponents.Abilities
{
    public class DefaultAttack : IAbility
    {
        private readonly ProjectileFactory _projectileFactory;
        private readonly DiContainer _diContainer;
        private readonly Player _player;

        private float _nextAttackTime;
        private float _timeBetweenAttacks = 1;

        public DefaultAttack(ProjectileFactory projectileFactory,
            DiContainer diContainer,
            Player player)
        {
            _projectileFactory = projectileFactory;
            _diContainer = diContainer;
            _player = player;
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
            var projectile = _projectileFactory.Get(_diContainer);

            var target = _player.GetNearestObject();

            if (target == null)
                return;

            projectile.SetDirection(target.transform.position - _player.transform.position);
            projectile.SetPosition(_player.transform.position);
        }
    }
}

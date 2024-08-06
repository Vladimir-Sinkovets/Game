using Assets.Scripts.Factories.ProjectileFactories;
using Assets.Scripts.Services.ProjectileAccessor;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.PlayerComponents.Abilities
{
    public class DefaultAttack : IAbility
    {
        private readonly ProjectileFactory _projectileFactory;
        private readonly DiContainer _diContainer;
        private readonly IProjectileStorage _projectileStorage;
        private readonly Player _player;

        private float _nextAttackTime;
        private float _timeBetweenAttacks = 1;

        public DefaultAttack(ProjectileFactory projectileFactory,
            DiContainer diContainer,
            IProjectileStorage projectileStorage,
            Player player)
        {
            _projectileFactory = projectileFactory;
            _diContainer = diContainer;
            _projectileStorage = projectileStorage;
            _player = player;
        }

        public void Update()
        {
            if (_nextAttackTime <= Time.time)
            {
                Attack();

                _nextAttackTime = Time.time + _timeBetweenAttacks;
            }
        }

        private void Attack()
        {
            var projectile = _projectileFactory.Get(_diContainer);

            projectile.SetDirection(Vector2.left);
            projectile.SetPosition(_player.transform.position);

            _projectileStorage.Add(projectile);
        }
    }
}

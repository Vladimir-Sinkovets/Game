using Assets.Scripts.PlayerComponents;
using Assets.Scripts.Services.ProjectileAccessor;
using System.Collections.Generic;
using Zenject;

namespace Assets.Scripts.Services.Controllers
{
    public class ProjectilesMover : IProjectilesController, ITickable
    {
        private readonly IProjectileStorage _projectileStorage;

        private IEnumerable<Projectile> Projectiles => _projectileStorage.Projectiles;

        public ProjectilesMover(IProjectileStorage projectileStorage)
        {
            _projectileStorage = projectileStorage;
        }

        public void Tick()
        {
            foreach (var projectile in Projectiles)
            {
                projectile.Move();
            }
        }
    }
}

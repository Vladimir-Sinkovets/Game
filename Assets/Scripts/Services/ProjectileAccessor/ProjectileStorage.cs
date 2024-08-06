using Assets.Scripts.PlayerComponents;
using System.Collections.Generic;

namespace Assets.Scripts.Services.ProjectileAccessor
{
    public class ProjectileStorage : IProjectileStorage
    {
        private readonly List<Projectile> _projectiles = new();
        public IEnumerable<Projectile> Projectiles => _projectiles;
        public void Add(Projectile projectile)
        {
            _projectiles.Add(projectile);
        }
    }
}

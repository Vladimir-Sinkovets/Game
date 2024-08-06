using Assets.Scripts.PlayerComponents;
using System.Collections.Generic;

namespace Assets.Scripts.Services.ProjectileAccessor
{
    public interface IProjectileStorage
    {
        IEnumerable<Projectile> Projectiles { get; }

        void Add(Projectile projectile);
    }
}
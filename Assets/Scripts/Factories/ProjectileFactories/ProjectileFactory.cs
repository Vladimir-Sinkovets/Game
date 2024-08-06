using Assets.Scripts.PlayerComponents;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Factories.ProjectileFactories
{
    [CreateAssetMenu(fileName = "Projectile", menuName = "Configs/Projectile")]
    public class ProjectileFactory : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private Sprite _sprite;

        public Projectile Get(DiContainer diContainer)
        {
            var projectile = diContainer.InstantiateComponentOnNewGameObject<Projectile>();

            projectile.Init(_speed, _sprite, 2.0f);

            return projectile;
        }
    }
}

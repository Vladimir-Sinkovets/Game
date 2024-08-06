using Assets.Scripts.PlayerComponents;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Factories.ProjectileFactories
{
    [CreateAssetMenu(fileName = "Projectile", menuName = "Configs/Projectile")]
    public class ProjectileFactory : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _damage;

        public Projectile Get(DiContainer diContainer)
        {
            var projectile = diContainer.InstantiateComponentOnNewGameObject<Projectile>();

            projectile.gameObject.layer = LayerMask.NameToLayer("Projectile");

            var collider = projectile.AddComponent<CircleCollider2D>();

            collider.radius = 0.25f;
            collider.isTrigger = true;

            projectile.Init(_speed, _sprite, 2.0f, _damage);

            return projectile;
        }
    }
}

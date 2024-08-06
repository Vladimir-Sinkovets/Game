using Assets.Scripts.Enemies;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Factories.EnemyFactories
{
    [CreateAssetMenu(fileName = "EnemyFactory", menuName = "Configs/EnemyFactory")]
    public class EnemyFactory : ScriptableObject
    {
        [SerializeField] protected int _hp = 10;
        [SerializeField] protected Sprite _sprite;
        [SerializeField] protected float _speed = 2.0f;
        [SerializeField] protected int _damage = 1;
        [SerializeField] protected float _colliderRadius = 0.5f;
        [SerializeField] protected float _timeBetweenHits = 1;

        public virtual Enemy Get(DiContainer container)
        {
            var enemy = container.InstantiateComponentOnNewGameObject<Enemy>();
            enemy.Init(_speed, _hp, _damage, _timeBetweenHits);
            enemy.gameObject.layer = LayerMask.NameToLayer("Enemy");

            var spriteRenderer = enemy.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = _sprite;
            spriteRenderer.transform.SetParent(enemy.transform);

            var collider = enemy.AddComponent<CircleCollider2D>();
            collider.radius = _colliderRadius;

            var rb = enemy.AddComponent<Rigidbody2D>();
            rb.isKinematic = true;

            return enemy;
        }
    }
}

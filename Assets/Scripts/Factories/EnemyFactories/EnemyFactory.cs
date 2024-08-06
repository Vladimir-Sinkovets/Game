using Assets.Scripts.Enemies;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Factories.EnemyFactories
{
    [CreateAssetMenu(fileName = "EnemyFactory", menuName = "Configs/EnemyFactory")]
    public class EnemyFactory : ScriptableObject
    {
        [SerializeField] protected int _hp;
        [SerializeField] protected Sprite _sprite;
        [SerializeField] protected float _speed;

        public virtual Enemy Get(DiContainer container)
        {
            var enemy = container.InstantiateComponentOnNewGameObject<Enemy>();
            enemy.Init(_speed, _hp);
            enemy.gameObject.layer = LayerMask.NameToLayer("Enemy");

            var spriteRenderer = container.InstantiateComponentOnNewGameObject<SpriteRenderer>();
            spriteRenderer.sprite = _sprite;
            spriteRenderer.transform.SetParent(enemy.transform);

            var collider = enemy.AddComponent<CircleCollider2D>();
            collider.radius = 0.5f;

            var rb = enemy.AddComponent<Rigidbody2D>();
            rb.isKinematic = true;


            return enemy;
        }
    }
}

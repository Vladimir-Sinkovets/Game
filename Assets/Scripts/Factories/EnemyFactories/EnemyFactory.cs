using Assets.Scripts.Enemies;
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

        public Enemy Get(DiContainer container)
        {
            var enemy = container.InstantiateComponentOnNewGameObject<Enemy>();
            enemy.Init(_speed, _hp);

            var spriteRenderer = container.InstantiateComponentOnNewGameObject<SpriteRenderer>();
            spriteRenderer.sprite = _sprite;
            spriteRenderer.transform.SetParent(enemy.transform);

            return enemy;
        }
    }
}

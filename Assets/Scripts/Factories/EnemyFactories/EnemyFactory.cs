using Assets.Scripts.Enemies;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Factories.EnemyFactories
{
    [CreateAssetMenu(fileName = "EnemyFactory", menuName = "Configs/EnemyFactory")]
    public class EnemyFactory : ScriptableObject
    {
        [SerializeField] protected Enemy _prefab;
        [Space]
        [SerializeField] protected int _hp = 10;
        [SerializeField] protected Sprite _sprite;
        [SerializeField] protected float _speed = 2.0f;
        [SerializeField] protected int _damage = 1;
        [SerializeField] protected float _timeBetweenHits = 1;

        public virtual Enemy Get(DiContainer container)
        {
            var enemy = container.InstantiatePrefabForComponent<Enemy>(_prefab);
            
            enemy.Init(_speed, _hp, _damage, _timeBetweenHits);

            var spriteRenderer = enemy.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = _sprite;

            return enemy;
        }
    }
}

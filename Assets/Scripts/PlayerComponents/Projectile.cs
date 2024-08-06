using Assets.Scripts.Enemies;
using System;
using UnityEngine;

namespace Assets.Scripts.PlayerComponents
{
    public class Projectile : MonoBehaviour
    {
        private float _speed;
        private Vector2 _direction = Vector2.zero;
        private int _damage;

        private float _lifeTime = 1.0f;
        private float _time = 0.0f;

        public void Init(float speed, Sprite sprite, float lifeTime, int damage)
        {
            _speed = speed;
            _lifeTime = lifeTime;
            _damage = damage;

            var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
        }

        public void Update()
        {
            if (_lifeTime <= _time)
            {
                Die();
            }

            _time += Time.deltaTime;

            transform.Translate(_direction * _speed * Time.deltaTime);
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction.normalized;
        }
        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var isEnemy = collision.TryGetComponent<Enemy>(out var enemy);

            if (isEnemy == false)
                return;

            enemy.MakeDamage(_damage);

            Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}

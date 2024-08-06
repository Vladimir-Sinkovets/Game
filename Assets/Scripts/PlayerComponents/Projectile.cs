using System;
using UnityEngine;

namespace Assets.Scripts.PlayerComponents
{
    public class Projectile : MonoBehaviour
    {
        private float _speed;
        private Vector2 _direction = Vector2.zero;

        //private float _maxLifeTime = 1.0f;
        //private float _lifeTime = 0.0f;

        public void Init(float speed, Sprite sprite)
        {
            _speed = speed;

            var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

            spriteRenderer.sprite = sprite;
        }

        public void Move()
        {
            //if (_maxLifeTime <= _lifeTime)
            //{
            //    Destroy(gameObject);
            //}

            //_lifeTime += Time.deltaTime;

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
    }
}

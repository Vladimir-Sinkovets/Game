using Assets.Scripts.PlayerComponents;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private float _speed;
        private int _hp;
        private Player _player;
        private int _damage;
        private float _timeBetweenHits;

        private float _nextHitTime;

        public float Speed { get => _speed; }

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }

        public virtual void Update()
        {
            Move();
        }

        private void Move()
        {
            var direction = _player.transform.position - transform.position;

            var distance = direction.magnitude;

            if (distance < 1)
            {
                DamagePlayer();
                return;
            }

            var normalizedDirection = direction / distance;

            transform.Translate(Speed * Time.deltaTime * normalizedDirection);
        }

        private void DamagePlayer()
        {
            if (_nextHitTime > Time.time)
                return;

            _nextHitTime = Time.time + _timeBetweenHits;

            _player.MakeDamage(_damage);
        }

        public virtual void Init(float speed, int hp, int damage, float timeBetweenHits)
        {
            _speed = speed;
            _hp = hp;
            _damage = damage;
            _timeBetweenHits = timeBetweenHits;
        }

        public void MakeDamage(int _damage)
        {
            _hp -= _damage;

            if (_hp < 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}

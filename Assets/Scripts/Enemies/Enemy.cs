using Assets.Scripts.PlayerComponents;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private float _speed;
        private int _hp;
        private Player _player;

        public float Speed { get => _speed; }

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }

        public virtual void Update()
        {
            var direction = _player.transform.position - transform.position;

            var distance = direction.magnitude;

            var normalizedDirection = direction / distance;

            if (distance < 1)
                return;

            transform.Translate(Speed * Time.deltaTime * normalizedDirection);
        }

        public virtual void Init(float speed, int hp)
        {
            _speed = speed;
            _hp = hp;
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
        }
    }
}

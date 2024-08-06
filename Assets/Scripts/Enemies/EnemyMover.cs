using Assets.Scripts.PlayerComponents;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemies
{
    public class EnemyMover : MonoBehaviour
    {
        public event Action<Player> OnTargetReached;

        private float _speed;
        private Player _player;

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }

        public void Init(float speed)
        {
            _speed = speed;
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
                OnTargetReached.Invoke(_player);

                return;
            }

            var normalizedDirection = direction / distance;

            transform.Translate(_speed * Time.deltaTime * normalizedDirection);
        }
    }
}

using Assets.Scripts.PlayerComponents;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private EnemyMover _enemyMover;
        private Health _enemyHealth;
        private int _damage;

        private float _timeBetweenHits;
        private float _nextHitTime;

        public virtual void Init(float speed, int hp, int damage, float timeBetweenHits)
        {
            _enemyMover = GetComponent<EnemyMover>();
            _enemyMover.Init(speed);
            _enemyMover.OnTargetReached += OnTargetReachedHandler;

            _enemyHealth = GetComponent<Health>();
            _enemyHealth.Init(hp);
            _enemyHealth.OnHpEnded += OnHpEndedHandler;

            _damage = damage;
            _timeBetweenHits = timeBetweenHits;
        }

        private void OnHpEndedHandler()
        {
            Destroy(gameObject);
        }

        private void OnTargetReachedHandler(Player player)
        {
            if (_nextHitTime > Time.time)
                return;

            _nextHitTime = Time.time + _timeBetweenHits;

            player.GetComponent<Health>()
                .MakeDamage(_damage);
        }
    }
}

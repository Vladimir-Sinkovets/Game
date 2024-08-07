using Assets.Scripts.PlayerComponents;
using Assets.Scripts.Services.EnemyEvents;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private IEnemyEventBus _enemyEvents;

        private EnemyMover _enemyMover;
        private Health _enemyHealth;

        private int _damage;
        private int _experience;

        private float _timeBetweenHits;
        private float _nextHitTime;

        public int Experience { get => _experience; }

        [Inject]
        private void Construct(IEnemyEventBus enemyEvents)
        {
            _enemyEvents = enemyEvents;
        }

        public virtual void Init(float speed, int hp, int damage, float timeBetweenHits, int experience)
        {
            _enemyMover = GetComponent<EnemyMover>();
            _enemyMover.Init(speed);
            _enemyMover.OnTargetReached += OnTargetReachedHandler;

            _enemyHealth = GetComponent<Health>();
            _enemyHealth.Init(hp);
            _enemyHealth.OnHpEnded += OnHpEndedHandler;

            _damage = damage;
            _timeBetweenHits = timeBetweenHits;
            _experience = experience;
        }

        private void OnHpEndedHandler()
        {
            _enemyEvents.EnemyDied(this);

            _enemyMover.OnTargetReached -= OnTargetReachedHandler;
            _enemyHealth.OnHpEnded -= OnHpEndedHandler;

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

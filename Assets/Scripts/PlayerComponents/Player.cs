using Assets.Scripts.Enemies;
using Assets.Scripts.PlayerComponents.Abilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.PlayerComponents
{
    public class Player : MonoBehaviour, IInitializable
    {
        [SerializeField] private int _hp = 100;

        private readonly List<IAbility> _abilities = new List<IAbility>();

        private DiContainer _diContainer;
        private Health _health;

        public List<IAbility> Abilities => _abilities;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Initialize()
        {
            _abilities.Add(_diContainer.Instantiate<DefaultAttack>());
            _health = GetComponent<Health>();
            _health.Init(_hp);
            _health.OnHpEnded += OnHpEndedHandler;
        }

        private void OnHpEndedHandler()
        {
            Debug.Log("player died");
        }

        private void Update()
        {
            foreach (var ability in _abilities)
            {
                ability.Update();
            }
        }

        public Enemy GetNearestObject()
        {
            var enemies = Physics2D.OverlapCircleAll(transform.position, 6, LayerMask.GetMask("Enemy"))
                .Where(x => x.TryGetComponent(out Enemy enemy));

            if (enemies.Count() == 0)
                return null;

            return enemies
                .Last()
                .GetComponent<Enemy>();
        }
    }
}

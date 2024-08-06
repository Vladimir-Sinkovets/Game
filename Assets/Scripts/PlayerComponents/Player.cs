using Assets.Scripts.Enemies;
using Assets.Scripts.PlayerComponents.Abilities;
using System;
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

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Initialize()
        {
            _abilities.Add(_diContainer.Instantiate<DefaultAttack>());
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

        public void MakeDamage(int damage)
        {
            _hp -= damage;

            if (_hp < 0)
                Die();
        }

        private void Die()
        {
            Debug.Log("player died");
        }
    }
}

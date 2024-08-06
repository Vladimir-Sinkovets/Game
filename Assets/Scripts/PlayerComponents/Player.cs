using Assets.Scripts.PlayerComponents.Abilities;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.PlayerComponents
{
    public class Player : MonoBehaviour, IInitializable
    {
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
    }
}

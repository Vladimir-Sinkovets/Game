using Assets.Scripts.Factories.ProjectileFactories;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.PlayerComponents.AbilitySettings
{
    [CreateAssetMenu(fileName = "DefaultAttackSettings", menuName = "Configs/DefaultAttackSettings")]
    public class DefaultAttackSettings : ScriptableObject
    {
        [SerializeField] private List<DefaultAttackLevelSettings> _levels;

        public List<DefaultAttackLevelSettings> Levels { get => _levels; }
    }
}

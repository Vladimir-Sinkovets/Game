using Assets.Scripts.Factories.ProjectileFactories;
using System;
using UnityEngine;

namespace Assets.Scripts.Settings.AbilitySettings
{
    [Serializable]
    public class DefaultAttackLevelSettings
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _timeBetweenAttack;
        [SerializeField] private ProjectileFactory _factory;

        public ProjectileFactory Factory { get => _factory; }
        public float TimeBetweenAttack { get => _timeBetweenAttack; }
        public Sprite Icon { get => _icon; }
    }
}
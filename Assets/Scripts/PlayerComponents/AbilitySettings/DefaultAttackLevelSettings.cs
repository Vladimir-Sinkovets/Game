﻿using Assets.Scripts.Factories.ProjectileFactories;
using System;
using UnityEngine;

namespace Assets.Scripts.PlayerComponents.AbilitySettings
{
    [Serializable]
    public class DefaultAttackLevelSettings
    {
        [SerializeField] private float _timeBetweenAttack;
        [SerializeField] private ProjectileFactory _factory;

        public ProjectileFactory Factory { get => _factory; }
        public float TimeBetweenAttack { get => _timeBetweenAttack; }
    }
}
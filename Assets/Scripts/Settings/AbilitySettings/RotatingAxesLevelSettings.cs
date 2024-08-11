using System;
using UnityEngine;

namespace Assets.Scripts.Settings.AbilitySettings
{
    [Serializable]
    public class RotatingAxesLevelSettings
    {
        [SerializeField] private float _rotatingSpeed;
        [SerializeField] private int _damage;

        public float RotatingSpeed { get => _rotatingSpeed; }
        public int Damage { get => _damage; }
    }
}

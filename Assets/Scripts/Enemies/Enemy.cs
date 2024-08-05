using System;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public float Speed { get => _speed; }
    }
}

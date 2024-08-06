using System;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private float _speed;
        private int _hp;

        public float Speed { get => _speed; }

        public void Init(float speed, int hp)
        {
            _speed = speed;
            _hp = hp;
        }
    }
}

using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Health : MonoBehaviour
    {
        public event Action OnHpEnded;
        public event Action<int, int> OnHpChanged;

        private int _hp;
        private int _maxHp;

        private int Hp
        {
            get => _hp; set
            {
                _hp = value;

                OnHpChanged?.Invoke(Hp, _maxHp);
            }
        }

        public void Init(int hp)
        {
            Hp = hp;
            _maxHp = hp;
        }

        public void MakeDamage(int _damage)
        {
            Hp -= _damage;

            if (Hp <= 0)
            {
                OnHpEnded?.Invoke();
            }
        }
    }
}

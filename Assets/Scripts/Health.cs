using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Health : MonoBehaviour
    {
        public event Action OnHpEnded;

        private int _hp;

        public void Init(int hp)
        {
            _hp = hp;
        }

        public void MakeDamage(int _damage)
        {
            _hp -= _damage;

            if (_hp < 0)
            {
                OnHpEnded.Invoke();
            }
        }
    }
}

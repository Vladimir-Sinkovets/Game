using UnityEngine;

namespace Assets.Scripts.PlayerComponents.Abilities
{
    public class AxeCollision : MonoBehaviour
    {
        private RotatingAxes _rotatingAxes;

        public void Init(RotatingAxes rotatingAxes)
        {
            _rotatingAxes = rotatingAxes;
        }

        private int Damage { get => _rotatingAxes.Damage; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Health>(out var health))
            {
                health.MakeDamage(Damage);
            }
        }
    }
}

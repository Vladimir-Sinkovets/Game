using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private float _speed;
        private int _hp;
        public float Speed { get => _speed; }
        public void Move(Vector3 target)
        {
            var direction = target - transform.position;

            var distance = direction.magnitude;

            var normalizedDirection = direction / distance;
            if (distance < 1)
                return;

            transform.Translate(Speed * Time.deltaTime * normalizedDirection);
        }

        public void Init(float speed, int hp)
        {
            _speed = speed;
            _hp = hp;
        }
    }
}

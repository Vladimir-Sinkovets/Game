using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public void MoveTo(Vector3 target)
        {
            var heading = target - transform.position;
            var direction = heading / heading.magnitude;

            transform.Translate(heading * _speed);
        }
    }
}

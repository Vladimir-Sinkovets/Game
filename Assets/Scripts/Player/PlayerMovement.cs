using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        private FixedJoystick _joystick;

        [Inject] private void Construct(FixedJoystick joystick)
        {
            _joystick = joystick;
        }

        private void Update()
        {
            _rigidbody.velocity = _joystick.Direction;
        }
    }
}
using DG.Tweening;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.UIComponents
{
    public class FloatingButton : MonoBehaviour
    {
        [SerializeField] private float _angle;
        [SerializeField] private float _duration;

        private Vector3 _startRotation;
        private Sequence _sequence;

        private void Start()
        {
            _startRotation = transform.rotation.eulerAngles;

            _sequence = DOTween.Sequence()
                .Append(transform.DORotate(new Vector3(0, 0, _angle), _duration).SetEase(Ease.Linear))
                .Append(transform.DORotate(new Vector3(0, 0, -_angle), _duration * 2).SetEase(Ease.Linear))
                .Append(transform.DORotate(_startRotation, _duration).SetEase(Ease.Linear))
                .SetLoops(-1);
        }

        private void OnDestroy()
        {
            _sequence.Kill();
        }
    }
}

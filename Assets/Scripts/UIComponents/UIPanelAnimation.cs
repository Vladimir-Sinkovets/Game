using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.UIComponents
{
    public class UIPanelAnimation : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private Vector2 _from = new(0, 4000f);
        [SerializeField] private Ease _inFunction = Ease.InOutElastic;
        [SerializeField] private Ease _outFunction = Ease.InOutElastic;

        private RectTransform _rect;
        private Vector3 _pos;

        public float Duration { get => _duration; }

        private void Start()
        {
            _rect = GetComponent<RectTransform>();

            _pos = _rect.anchoredPosition;

            _rect.anchoredPosition = _from;
        }

        public void PlayInAnimation()
        {
            _rect.DOAnchorPosY(_pos.y, _duration)
                .SetEase(_inFunction)
                .SetUpdate(true);
        }
        public void PlayOutAnimation()
        {
            _rect.DOAnchorPosY(_from.y, _duration)
                .SetEase(_outFunction)
                .SetUpdate(true);
        }
    }
}

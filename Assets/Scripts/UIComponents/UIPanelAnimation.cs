using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.UIComponents
{
    public class UIPanelAnimation : MonoBehaviour
    {
        [SerializeField] private float _animationTime = 0.5f;
        [SerializeField] private Vector2 _from = new(0, 4000f);
        [SerializeField] private Ease _inFunction = Ease.InOutElastic;
        [SerializeField] private Ease _outFunction = Ease.InOutElastic;

        private RectTransform _rect;
        private Vector3 _pos;

        private void Start()
        {
            _rect = GetComponent<RectTransform>();

            _pos = _rect.anchoredPosition;

            _rect.anchoredPosition = _from;
        }

        public void PlayInAnimation()
        {
            _rect.DOAnchorPosY(_pos.y, _animationTime)
                .SetEase(_inFunction)
                .SetUpdate(true);
        }
        public void PlayOutAnimation()
        {
            _rect.DOAnchorPosY(_from.y, _animationTime)
                .SetEase(_outFunction)
                .SetUpdate(true);
        }
    }
}

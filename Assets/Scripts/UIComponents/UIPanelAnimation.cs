using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UIComponents
{
    public class UIPanelAnimation : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private Vector2 _from = new(0, 4000f);
        [SerializeField] private Ease _inFunction = Ease.InOutElastic;
        [SerializeField] private Ease _outFunction = Ease.InOutElastic;
        [Space]
        [SerializeField] private List<Transform> _items;
        [SerializeField] private Ease _itemInFunction = Ease.InOutBounce;
        [SerializeField] private float _itemAnimationDuration = 0.3f;

        private RectTransform _rect;
        private Vector3 _pos;

        public float Duration { get => _duration; }

        public void AddItem(Transform item) => _items.Add(item);

        private void Start()
        {
            _rect = GetComponent<RectTransform>();

            _pos = _rect.anchoredPosition;

            _rect.anchoredPosition = _from;
        }

        public void PlayInAnimation()
        {
            foreach (var item in _items)
            {
                item.localScale = Vector3.zero;
            }

            _rect.DOAnchorPosY(_pos.y, _duration)
                .SetEase(_inFunction)
                .SetUpdate(true)
                .OnComplete(AnimateItems);
        }

        public void PlayOutAnimation()
        {
            _rect.DOAnchorPosY(_from.y, _duration)
                .SetEase(_outFunction)
                .SetUpdate(true);
        }

        private void AnimateItems()
        {
            foreach (var item in _items)
            {
                item.DOScale(1, _itemAnimationDuration)
                    .SetEase(_itemInFunction)
                    .SetUpdate(true);
            }
        }
    }
}

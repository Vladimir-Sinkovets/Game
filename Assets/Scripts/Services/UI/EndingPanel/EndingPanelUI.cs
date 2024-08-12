using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Services.UI.EndingPanel
{
    public class EndingPanelUI : MonoBehaviour, IEndingPanelUI
    {
        [SerializeField] private RectTransform _endingPanel;
        [SerializeField] private float _appearanceTime = 0.5f;

        private Vector3 _pos;

        private void Start()
        {
            _pos = _endingPanel.anchoredPosition;

            _endingPanel.anchoredPosition -= new Vector2(0, 4000f);
        }

        public void Show()
        {
            _endingPanel.gameObject.SetActive(true);

            _endingPanel.DOAnchorPosY(_pos.y, _appearanceTime)
                .SetEase(Ease.OutQuad)
                .SetUpdate(true);
        }
    }
}

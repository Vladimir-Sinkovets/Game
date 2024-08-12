using Assets.Scripts.UIComponents;
using UnityEngine;

namespace Assets.Scripts.Services.UI.EndingPanel
{
    public class EndingPanelUI : MonoBehaviour, IEndingPanelUI
    {
        [SerializeField] private RectTransform _endingPanel;
        [SerializeField] private UIPanelAnimation _animation;

        public void Show()
        {
            _endingPanel.gameObject.SetActive(true);

            _animation?.PlayInAnimation();
        }
    }
}

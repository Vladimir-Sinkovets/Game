using UnityEngine;
using Zenject;

namespace Assets.Scripts.Services.UI.EndingPanel
{
    public class EndingPanelUI : MonoBehaviour, IEndingPanelUI
    {
        [SerializeField] private GameObject _endingPanel;

        public void Show()
        {
            _endingPanel.SetActive(true);
        }
    }
}

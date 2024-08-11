using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Services.UI.Progress
{
    public class BarUI : MonoBehaviour, IBarUI
    {
        [SerializeField] private Image _bar;
        [SerializeField] private TMP_Text _text;

        public void SetValue(int current, int max)
        {
            _text.text = $"{current} / {max}";
            _bar.fillAmount = current / (float)max;
        }
    }
}

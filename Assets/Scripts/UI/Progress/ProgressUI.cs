using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Progress
{
    public class ProgressUI : MonoBehaviour, IProgressUI
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

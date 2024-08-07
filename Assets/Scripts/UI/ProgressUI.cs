using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ProgressUI : MonoBehaviour, IProgressUI
    {
        [SerializeField] private Image _bar;
        [SerializeField] private TMP_Text _text;

        public void SetValue(int current, int max)
        {
            _text.text = $"{current} / {max}";
            _bar.fillAmount = (float) current / (float) max;
        }
    }
}

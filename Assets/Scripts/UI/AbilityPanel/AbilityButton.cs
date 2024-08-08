using Assets.Scripts.PlayerComponents.Abilities;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.AbilityPanel
{
    public class AbilityButton : MonoBehaviour
    {
        public event Action OnClick;

        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;
        private IAbility _ability;

        public void Init(IAbility ability)
        {
            _ability = ability;
        }

        public void UpdateButton()
        {
            _image.sprite = _ability.Sprite;
            _text.text = _ability.Level.ToString();

            if (_ability.Level == _ability.MaxLevel)
            {
                _button.interactable = false;
            }
        }

        public void Click() => OnClick?.Invoke();
    }
}

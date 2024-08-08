﻿using Assets.Scripts.PlayerComponents;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.AbilityPanel
{
    public class AbilityPanelUI : MonoBehaviour, IInitializable
    {
        public event Action OnSkillUpgraded;

        [SerializeField] private GameObject _panel;
        [SerializeField] private Transform _container;

        [Space]
        [SerializeField] private AbilityButton _prefab;

        private Player _player;
        private List<AbilityButton> _buttons = new();

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }

        public void Initialize()
        {
            foreach (var ability in _player.Abilities)
            {
                var button = Instantiate(_prefab, _container);

                button.OnClick += () => 
                {
                    ability.IncreaseLevel();

                    OnSkillUpgraded?.Invoke();
                };

                button.Init(ability);

                _buttons.Add(button);
            }
        }
        

        public void Show()
        {
            _panel.SetActive(true);

            foreach (var button in _buttons)
            {
                button.UpdateButton();
            }
        }
        public void Hide()
        {
            _panel.SetActive(false);
        }
    }
}

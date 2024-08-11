using Assets.Scripts.PlayerComponents.Abilities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Settings.AbilitySettings
{
    [CreateAssetMenu(fileName = "RotatingAxesSettings", menuName = "Configs/RotatingAxesSettings")]
    public class RotatingAxesSettings : ScriptableObject
    {
        [SerializeField] private List<RotatingAxesLevelSettings> _levels;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Axes _prefab;

        public List<RotatingAxesLevelSettings> Levels { get => _levels; }
        public Sprite Icon { get => _icon; }

        public Axes GetAxes(Transform transform)
        {
            var axes = Instantiate(_prefab, transform);

            axes.transform.position = Vector2.zero;

            return axes;
        }
    }
}

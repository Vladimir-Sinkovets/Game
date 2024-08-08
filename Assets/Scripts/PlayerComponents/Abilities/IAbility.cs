using UnityEngine;

namespace Assets.Scripts.PlayerComponents.Abilities
{
    public interface IAbility
    {
        int Level { get; }
        int MaxLevel { get; }
        Sprite Sprite { get; }

        void IncreaseLevel();
        void Update();
    }
}
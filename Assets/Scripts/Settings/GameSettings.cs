using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Settings
{
    [CreateAssetMenu(fileName = "Game_Settings", menuName = "Configs/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private List<LevelSettings> _levels;

        public IList<LevelSettings> LevelSettings { get => _levels; }
    }
}
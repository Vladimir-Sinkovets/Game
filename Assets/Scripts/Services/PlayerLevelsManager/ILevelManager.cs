using Assets.Scripts.Settings;
using System;

namespace Assets.Scripts.Services.PlayerLevelsManager
{
    public interface ILevelManager
    {
        event Action<LevelSettings, int> OnLevelChanged;
        event Action<int, int> OnExperienceChanged;

        void Init();
    }
}
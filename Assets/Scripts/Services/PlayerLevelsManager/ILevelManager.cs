using Assets.Scripts.Settings;
using System;

namespace Assets.Scripts.Services.PlayerLevelsManager
{
    public interface ILevelManager
    {
        event Action<LevelSettings> OnLevelChanged;
        event Action<int> OnExperienceChanged;

        void Init();
    }
}
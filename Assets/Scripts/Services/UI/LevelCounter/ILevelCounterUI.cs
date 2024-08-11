using Assets.Scripts.Settings;

namespace Assets.Scripts.Services.UI.LevelCounter
{
    public interface ILevelCounterUI
    {
        void ChangeLevelTextCount(LevelSettings levelSettings, int level);
    }
}
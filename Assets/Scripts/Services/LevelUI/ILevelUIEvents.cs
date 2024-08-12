using System;

namespace Assets.Scripts.Services.LevelUI
{
    public interface ILevelUIEvents
    {
        event Action OnMenuButtonClick;
    }
}
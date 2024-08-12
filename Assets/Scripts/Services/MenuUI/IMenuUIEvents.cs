using System;

namespace Assets.Scripts.Services.MenuUI
{
    public interface IMenuUIEvents
    {
        event Action OnStartButtonClicked;
    }
}
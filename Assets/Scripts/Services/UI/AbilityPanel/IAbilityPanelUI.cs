using System;

namespace Assets.Scripts.Services.UI.AbilityPanel
{
    public interface IAbilityPanelUI
    {
        event Action OnSkillUpgraded;

        void Hide();
        void Init();
        void Show();
    }
}
using Assets.Scripts.Settings;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.LevelCounter
{
    public class LevelCounterUI : MonoBehaviour, ILevelCounterUI
    {
        [SerializeField] private TMP_Text _text;

        public void ChangeLevelTextCount(LevelSettings levelSettings, int level)
        {
            _text.text = $"Level: {level + 1}";
        }
    }
}

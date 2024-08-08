using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.PlayerComponents.Abilities
{
    public class Axes : MonoBehaviour
    {
        [SerializeField] private List<AxeCollision> axes;

        public void Init(RotatingAxes rotatingAxes)
        {
            foreach (var axe in axes)
            {
                axe.Init(rotatingAxes);
            }
        }
    }
}

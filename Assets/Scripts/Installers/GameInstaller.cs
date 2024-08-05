using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private FixedJoystick _joystick;

    public override void InstallBindings()
    {
        Container.Bind<FixedJoystick>()
            .FromInstance(_joystick);
    }
}

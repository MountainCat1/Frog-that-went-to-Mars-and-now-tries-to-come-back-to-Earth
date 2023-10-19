using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ShooterPlayerInput>().FromComponentInHierarchy().AsSingle();
        Container.Bind<RunnerPlayerInput>().FromComponentInHierarchy().AsSingle();
    }
}

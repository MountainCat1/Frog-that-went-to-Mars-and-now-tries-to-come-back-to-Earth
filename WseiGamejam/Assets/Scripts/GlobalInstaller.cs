using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller<GlobalInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerManager>().FromComponentInHierarchy().AsSingle();
    }
}
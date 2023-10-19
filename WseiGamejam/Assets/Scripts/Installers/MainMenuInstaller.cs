using UnityEngine.InputSystem;
using Zenject;

namespace Installers
{
    public class MainMenuInstaller : MonoInstaller<MainMenuInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerInputManager>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<PlayerManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}
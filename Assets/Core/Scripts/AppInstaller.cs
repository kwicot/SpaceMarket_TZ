using SpaceMarket.Core.Scipts.Obstacles.UI;
using Zenject;

namespace SpaceMarket.Core.Scipts.Obstacles
{
    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PopUpWindow>()
                .FromNew().AsSingle();
            
            Container.Bind<IMovementInputService>().
        }
    }
}
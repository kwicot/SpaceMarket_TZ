using System.Threading.Tasks;

namespace SpaceMarket.Core.Scipts.UI
{
    public interface IWindowAnimation
    {
        public Task PlayShowAnimation();
        public Task PlayHideAnimation();
    }
}
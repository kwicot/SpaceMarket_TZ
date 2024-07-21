using System.Threading.Tasks;

namespace SpaceMarket.Core.Scripts.Popup.UI
{
    public interface IPopupService
    {
        public Task Show();
        public Task Hide();
    }
}
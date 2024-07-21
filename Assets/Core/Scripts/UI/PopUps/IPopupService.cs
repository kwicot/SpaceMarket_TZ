using System.Threading.Tasks;

namespace SpaceMarket.Core.Scripts.Popup.UI
{
    public interface IPopupService
    {
        public bool IsShowing { get; }
        public Task Show(int delayMs);
        public Task Hide(int delayMs);
    }
}
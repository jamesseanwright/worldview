using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;

namespace UnsplashRoulette.Device
{
    class UwpViewport : Viewport
    {
        public override Size GetNormalisedAppSize()
        {
            Rect visibleBounds = ApplicationView.GetForCurrentView().VisibleBounds;
            double devicePixelRatio = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            double width = (visibleBounds.X * 2 + visibleBounds.Width) * devicePixelRatio;
            double height = (visibleBounds.Y * 2 + visibleBounds.Height) * devicePixelRatio;

            return new Size(width, height);
        }
    }
}

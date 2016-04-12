using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;

namespace WorldView.Device
{
    class UwpViewport : Viewport
    {
        public override Size GetNormalisedAppSize()
        {
            Rect visibleBounds = ApplicationView.GetForCurrentView().VisibleBounds;
            double devicePixelRatio = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            double width = visibleBounds.Width * devicePixelRatio;
            double height = visibleBounds.Height * devicePixelRatio;

            return new Size(width, height);
        }
    }
}

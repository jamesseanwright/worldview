using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UnsplashRoulette.ImageControls
{
    public sealed partial class CrossFadingImage : UserControl
    {
        public CrossFadingImage()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source",
            typeof(Stream),
            typeof(CrossFadingImage),
            new PropertyMetadata(string.Empty, async (i, args) => await OnImageChangedAsync(i, args))
        );

        public Stream Source
        {
            get
            {
                return (Stream) GetValue(SourceProperty);
            }

            set
            {
                SetValue(SourceProperty, value);
            }
        }

        private static async Task OnImageChangedAsync(object instance, DependencyPropertyChangedEventArgs args)
        {
            CrossFadingImage imageControl = (CrossFadingImage) instance;
            Stream newSource = (Stream) args.NewValue;
            imageControl.MakeCurrentImageStale();
            await imageControl.UpdateImageAsync(newSource);
        }

        private void MakeCurrentImageStale()
        {
            if (CurrentImage.Source != null)
            {
                StaleImage.Source = CurrentImage.Source;
                VisualStateManager.GoToState(this, "OnImageStale", false);
            }
        }

        private async Task UpdateImageAsync(Stream newSource)
        {
            MemoryStream memoryStream = new MemoryStream();
            await newSource.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            BitmapImage image = new BitmapImage();
            image.ImageOpened += (s, a) => OnImageLoaded(image);
            await image.SetSourceAsync(memoryStream.AsRandomAccessStream());
        }

        private void OnImageLoaded(BitmapImage image)
        {
            CurrentImage.Source = image;
            VisualStateManager.GoToState(this, "OnImageChanged", false);
        }
    }
}

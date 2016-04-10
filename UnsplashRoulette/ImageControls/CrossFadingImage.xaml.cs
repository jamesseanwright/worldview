using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            typeof(string),
            typeof(CrossFadingImage),
            new PropertyMetadata(string.Empty, LoadImage)
        );
        
        public string Source
        {
            get
            {
                return (string) GetValue(SourceProperty);
            }

            set
            {
                SetValue(SourceProperty, value);
            }
        }

        public string StaleSource { get; private set; }

        private static void LoadImage(object instance, DependencyPropertyChangedEventArgs args)
        {
            CrossFadingImage imageControl = (CrossFadingImage) instance;
            string newSource = (string) args.NewValue;

            BitmapImage image = new BitmapImage();
            image.ImageOpened += (s, a) => imageControl.OnImageLoaded(image);
            image.UriSource = new Uri(newSource);
        }

        private void OnImageLoaded(BitmapImage image)
        {
            CurrentPhoto.Source = image;
        }
    }
}

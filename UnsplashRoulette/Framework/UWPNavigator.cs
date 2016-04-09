using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UnsplashRoulette.Framework
{
    public class UWPNavigator : Navigator
    {
        readonly Frame rootFrame;
        ViewResolver viewResolver;

        public UWPNavigator(ViewResolver viewResolver)
        {
            this.viewResolver = viewResolver;
            this.rootFrame = (Frame)Window.Current.Content;
        }

        public override void Navigate(Type viewModel)
        {
            this.rootFrame.Navigate(viewResolver.GetFromViewModel(viewModel));
        }
    }
}

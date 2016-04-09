using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UnsplashRoulette.Framework
{
    public class UwpNavigator : Navigator
    {
        readonly Frame rootFrame;
        ViewResolver viewResolver;

        public UwpNavigator(ViewResolver viewResolver)
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

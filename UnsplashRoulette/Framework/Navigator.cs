using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UnsplashRoulette.Framework
{
    public class Navigator : INavigator
    {
        readonly Frame rootFrame;
        IViewResolver viewResolver;

        public Navigator(IViewResolver viewResolver)
        {
            this.viewResolver = viewResolver;
            this.rootFrame = (Frame)Window.Current.Content;
        }

        public void Navigate(Type viewModel)
        {
            this.rootFrame.Navigate(viewResolver.GetFromViewModel(viewModel));
        }
    }
}

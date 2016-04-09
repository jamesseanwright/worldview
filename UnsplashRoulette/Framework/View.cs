using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UnsplashRoulette.Framework
{
    public abstract class View : Page
    {
        ViewModel viewModel;

        public View()
        {
            Loaded += ViewLoaded;
            Unloaded += ViewUnloaded;
        }

        void ViewUnloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= ViewLoaded;
            Unloaded -= ViewUnloaded;
        }

        void ViewLoaded(object sender, RoutedEventArgs e)
        {
            this.viewModel = DataContext as ViewModel;
            this.viewModel?.OnNavigatedTo();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            this.viewModel?.OnNavigatedFrom();
        }
    }
}

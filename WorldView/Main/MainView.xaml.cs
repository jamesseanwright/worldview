using WorldView.Framework;
using WorldView.Photos;
using WorldView.Device;
using WorldView.Music;
using Windows.UI.Xaml;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WorldView.Main
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainView : View
    {
        public MainView()
        {
            this.InitializeComponent();
            DataContext = DependencyInjector.Instance.CreateInstance<MainViewModel>(typeof(PhotoService), typeof(Viewport), typeof(MusicLoader));
        }

        private void OnTrackEnded(object sender, RoutedEventArgs e)
        {
            MainViewModel viewModel = (MainViewModel) DataContext;
            viewModel.OnTrackEnded();
        }
    }
}

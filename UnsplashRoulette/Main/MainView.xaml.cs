using UnsplashRoulette.Framework;
using UnsplashRoulette.Photos;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UnsplashRoulette.Main
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainView : View
    {
        public MainView()
        {
            this.InitializeComponent();
            DataContext = DependencyInjector.Instance.CreateInstance<MainViewModel>(typeof(IPhotoService));
        }
    }
}

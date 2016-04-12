using WorldView.Framework;
using WorldView.Main;
using WorldView.Data;
using WorldView.Photos;
using WorldView.Photos.Unsplash;
using WorldView.Device;
using WorldView.Music;

namespace WorldView
{
    class Dependencies
    {
        public static void Register(DependencyInjector injector)
        {
            injector.CreateSingleton<ViewResolver, UwpViewResolver>();
            injector.CreateSingleton<Navigator,  UwpNavigator>(typeof(ViewResolver));
            injector.CreateSingleton<Viewport,  UwpViewport>();
            injector.CreateSingleton<MusicLoader, UwpMusicLoader>();
            injector.CreateSingleton<HttpService, UwpHttpService>();
            injector.CreateSingleton<Deserialiser, JsonDeserialiser>();
            injector.CreateSingleton<PhotoService, UnsplashService>(typeof(HttpService), typeof(Deserialiser));

            ViewResolver viewResolver = injector.GetSingleton<ViewResolver>();
            viewResolver.Register<MainViewModel, MainView>();
        }
    }
}

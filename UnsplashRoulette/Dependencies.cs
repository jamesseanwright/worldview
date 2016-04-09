using UnsplashRoulette.Framework;
using UnsplashRoulette.Main;

namespace UnsplashRoulette
{
    class Dependencies
    {
        public static void Register(DependencyInjector injector)
        {
            injector.CreateSingleton<ViewResolver, UWPViewResolver>();
            injector.CreateSingleton<Navigator,  UWPNavigator>(typeof (ViewResolver));

            ViewResolver viewResolver = injector.GetSingleton<ViewResolver>();
            viewResolver.Register<MainViewModel, MainView>();
        }
    }
}

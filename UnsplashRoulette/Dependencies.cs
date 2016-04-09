using UnsplashRoulette.Framework;
using UnsplashRoulette.Main;

namespace UnsplashRoulette
{
    class Dependencies
    {
        public static void Register(DependencyInjector injector)
        {
            injector.CreateSingleton<ViewResolver, UwpViewResolver>();
            injector.CreateSingleton<Navigator,  UwpNavigator>(typeof (ViewResolver));

            ViewResolver viewResolver = injector.GetSingleton<ViewResolver>();
            viewResolver.Register<MainViewModel, MainView>();
        }
    }
}

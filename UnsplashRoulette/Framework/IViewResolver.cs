using System;

namespace UnsplashRoulette.Framework
{
    public interface IViewResolver
    {
        Type GetFromViewModel(Type viewModel);
        void Register<TView, TViewModel>();
    }
}

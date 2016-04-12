using System;

namespace WorldView.Framework
{
    public abstract class ViewResolver
    {
        public abstract Type GetFromViewModel(Type viewModel);
        public abstract void Register<TView, TViewModel>();
    }
}

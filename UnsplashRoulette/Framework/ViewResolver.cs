using System;
using System.Collections.Generic;

namespace UnsplashRoulette.Framework
{
    public class ViewResolver : IViewResolver
    {
        Dictionary<Type, Type> mappings;

        public ViewResolver()
        {
            this.mappings = new Dictionary<Type, Type>();
        }

        public Type GetFromViewModel(Type viewModel)
        {
            Type outRef = null;

            if (this.mappings.TryGetValue(viewModel, out outRef))
            {
                return outRef;
            }

            return null;
        }


        public void Register<TViewModel, TView>()
        {
            this.mappings.Add(typeof (TViewModel), typeof(TView));
        }
    }
}

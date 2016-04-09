using System;
using System.Collections.Generic;

namespace UnsplashRoulette.Framework
{
    public class UWPViewResolver : ViewResolver
    {
        Dictionary<Type, Type> mappings;

        public UWPViewResolver()
        {
            this.mappings = new Dictionary<Type, Type>();
        }

        public override Type GetFromViewModel(Type viewModel)
        {
            Type outRef = null;

            if (this.mappings.TryGetValue(viewModel, out outRef))
            {
                return outRef;
            }

            return null;
        }


        public override void Register<TViewModel, TView>()
        {
            this.mappings.Add(typeof (TViewModel), typeof(TView));
        }
    }
}

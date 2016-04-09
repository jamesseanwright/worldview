using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnsplashRoulette.Framework
{
    public class DependencyInjector
    {
        static DependencyInjector instance;

        static DependencyInjector()
        {
            instance = new DependencyInjector();
        }

        public static DependencyInjector Instance
        {
            get
            {
                return instance;
            }
        }

        Dictionary<Type, object> singletons;

        private DependencyInjector()
        {
            this.singletons = new Dictionary<Type, object>();
        }

        public void CreateSingleton<TSource, TTarget>(params Type[] dependencies)
        {
            this.singletons.Add(typeof(TSource), CreateInstance<TTarget>(dependencies));
        }

        public TSource GetSingleton<TSource>()
        {
            object outRef = null;

            if (this.singletons.TryGetValue(typeof(TSource), out outRef))
            {
                return (TSource)outRef;
            }

            return default(TSource);
        }

        public T CreateInstance<T>(params Type[] dependencies)
        {
            TypeInfo typeInfo = typeof(T).GetTypeInfo();

            ConstructorInfo constructor = typeInfo.DeclaredConstructors.FirstOrDefault(c =>
            {
                return c.GetParameters().Count(p => dependencies.Contains(p.ParameterType)) == dependencies.Length;
            });

            return (T)constructor.Invoke(dependencies.Select(d =>
            {
                return this.singletons.FirstOrDefault(kvp => kvp.Key == d).Value;
            }).ToArray<object>());
        }
    }
}

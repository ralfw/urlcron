using System;
using System.Collections.Generic;

namespace dependencylocator
{
    public static class Resolver {
        private static readonly Dictionary<Type, Func<object>> __factories = new Dictionary<Type, Func<object>>();
        
        public static void Clear() => __factories.Clear();
        
        public static void Add<T>(Func<object> typefactory) => __factories.Add(typeof(T), typefactory); 
        public static T Get<T>() => (T)__factories[typeof(T)]();
    }
}
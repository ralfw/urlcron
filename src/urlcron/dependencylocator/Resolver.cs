using System;
using System.Collections.Generic;

namespace dependencylocator
{
    public static class Resolver
    {
        private static readonly Dictionary<Type, Func<object>> factories = new Dictionary<Type, Func<object>>();
        
        public static void Add<T>(Func<object> typefactory) => factories.Add(typeof(T), typefactory); 

        public static T Get<T>() => (T)factories[typeof(T)]();

        public static void Clear() => factories.Clear();
    }
}
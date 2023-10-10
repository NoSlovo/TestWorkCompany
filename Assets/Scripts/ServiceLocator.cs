using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ServiceLocator
    {
        private ServiceLocator()
        {
        }

        private readonly Dictionary<Type, IScreen> _services = new Dictionary<Type, IScreen>();

        public static ServiceLocator Current { get; private set; }

        public static void Initialize()
        {
            Current = new ServiceLocator();
        }

        public T Get<T>() where T : IScreen
        {
            var key = typeof(T);

            return (T)_services[key];
        }

        public void Register<T>(T service) where T : IScreen
        {
            var key = typeof(T);
            if (_services.ContainsKey(key))
            {
                Debug.LogError(
                    $"Attempted to register service of type {key} which is already registered with the {GetType().Name}.");
                return;
            }

            _services.Add(key, service);
        }

        public void Unregister<T>() where T : IScreen
        {
            var key = typeof(T);

            _services.Remove(key);
        }
    }

    public interface IScreen
    {
    }
}
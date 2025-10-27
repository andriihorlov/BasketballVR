using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fidgetland.ServiceLocator
{
    public class Service
    {
        public static Service Instance { get; private set; }
        
        private Service() { }

        private readonly Dictionary<string, IService> _services = new Dictionary<string, IService>();

        public static void Initialize()
        {
            if (Instance != null) return;
            Instance = new Service();
        }

        public T Get<T>() where T : IService
        {
            string key = typeof(T).Name;
            if (!_services.ContainsKey(key))
            {
                Debug.LogError($"{key} not registered with {GetType().Name}");
                throw new InvalidOperationException();
            }

            return (T)_services[key];
        }

        public void Register<T>(T service) where T : IService
        {
            string key = typeof(T).Name;
            if (_services.ContainsKey(key))
            {
                Debug.LogError(
                    $"Attempted to register service of type {key} which already registered with {GetType().Name}");
                return;
            }

            _services.Add(key, service);
        }

        public void Unregister<T>() where T : IService
        {
            string key = typeof(T).Name;
            if (!_services.ContainsKey(key))
            {
                Debug.LogError(
                    $"Attempted to unregister service of type {key} which already registered with {GetType().Name}");
            }

            _services.Remove(key);
        }
    }
}
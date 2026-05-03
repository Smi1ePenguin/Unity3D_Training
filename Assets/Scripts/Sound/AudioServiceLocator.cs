using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
public static class AudioServiceLocator
{
    private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

    public static void Register<T>(T service)
    {
        var type = typeof(T);
        if (_services.ContainsKey(type))
        {
            Debug.LogWarning($"{type} 이 이미 있음.");
        }
        _services[type] = service;
    }

    public static T Get<T>()
    {
        var type = typeof(T);
        
        if(_services.ContainsKey(type))
        {
            return (T)_services[type];
        }
        else
        {
            Debug.LogError($"{type} 이 없음.");
            return default;
        }
    }
}

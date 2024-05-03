using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Object
{
    private Queue<T> _bullets;
    private Object _prefab;
    public ObjectPool(Object newPrefab)
    {
        _bullets = new Queue<T>();
        _prefab = newPrefab;
        
    }
    public T Get()
    {
        return _bullets.Count > 0 ? _bullets.Dequeue() : Create();
    }
    public T Create()
    {
        return (T)Object.Instantiate(_prefab);
    }

    public void Release(T obj)
    {
        _bullets.Enqueue(obj);
    }
}

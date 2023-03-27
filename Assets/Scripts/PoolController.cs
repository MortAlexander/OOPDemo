using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    public static PoolController Instance { get; private set; }
    [SerializeField] private GameObject FallingSphere;
    [SerializeField] private GameObject FallingBox;
    private Queue<GameObject> _queue = new Queue<GameObject>();
    [SerializeField] private int NumberOfObjects;
    private List<GameObject> pooledOjs = new List<GameObject>();
    private void Awake()
    {
        Instance = this;
    }

    public void CreatePool()
    {
        for (int i = 0; i < NumberOfObjects; i++)
        {
            var _sphere= Instantiate(FallingSphere, transform);
            _queue.Enqueue(_sphere);
            var _box= Instantiate(FallingBox, transform);
            _queue.Enqueue(_box);
            pooledOjs.Add(_sphere);
            pooledOjs.Add(_box);
        }
    }

    public GameObject GetFallingObject()
    {
        if (_queue.Peek()!=null)
        {
            return _queue.Dequeue();
        }

        throw new MissingComponentException("outOfObjectsInPool");
    }

    public void Return(GameObject _obj)
    {
        _queue.Enqueue(_obj);
        _obj.transform.position=Vector3.zero;
    }

    public void Hide()
    {
        var pooledObjects = GetComponentsInChildren(typeof(Transform));
        for (int i = 1; i < pooledObjects.Length; i++)
        {
            pooledObjects[i].gameObject.SetActive(false);
        }
       
    }

    public void ChangeColor(Color c)
    {
        foreach (var VARIABLE in pooledOjs)
        {
            VARIABLE.GetComponent<SpriteRenderer>().color = c;
        }
    }
}

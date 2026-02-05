using System.Collections.Generic;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int initPoolSize;
    [SerializeField] private PooledObject objectToPool; // script attached to an object to be pooled 

    private Stack<PooledObject> stack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupPool();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetupPool()
    {
        stack = new Stack<PooledObject>();
        PooledObject instance = null;

        for (int i=0; i< initPoolSize; i++)
        {
            instance = Instantiate(objectToPool);
            instance.Pool = this;
            instance.gameObject.SetActive(false);
            stack.Push(instance);
        }
    }

    public PooledObject GetPooledObject()
    {
        // if the pool is not large enough, instantiate a new Pooled Objects 

        if(stack.Count == 0)
        {
            PooledObject newInstance = Instantiate(objectToPool);
            newInstance.Pool = this; 
            return newInstance;
        }

        // otherwise, just gran the next one from the last 
        PooledObject nextInstance = stack.Pop();
        nextInstance.gameObject.SetActive(true);
        return nextInstance;

    }

    public void ReturnToPool(PooledObject pooledObject)
    {
        stack.Push(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }
}

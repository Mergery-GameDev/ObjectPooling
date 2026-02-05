using System;
using System.Collections; // Required for IEnumerator
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeterminer : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private float minSpawnTime = 1f; // Minimum possible delay
    [SerializeField] private float maxSpawnTime = 5f; // Maximum possible delay
    
    private PoolObjectType type;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true) 
        {
            int random = UnityEngine.Random.Range(0, 6);
            SelectType(random);
            SpawnObject(type);

            // 1. Generate a NEW random interval for THIS cycle
            float waitTime = UnityEngine.Random.Range(minSpawnTime, maxSpawnTime);
            
            // 2. Wait for that specific random amount of time
            yield return new WaitForSeconds(waitTime);
        }
    }


    private void SelectType(int random)
    {
        if(random ==0)
        {
            type = PoolObjectType.Cube ;
        }
        else if(random ==1)
        {
            type = PoolObjectType.Cylinder ;
        }
        else if(random ==2)
        {
            type = PoolObjectType.Capsule ;
        }
        else if(random ==3)
        {
            type = PoolObjectType.Sphere ;
        }
        else if(random ==4)
        {
            type = PoolObjectType.Squidward ;
        }
        else if(random ==5)
        {
            type = PoolObjectType.Cross ;
        }

    }

    private void SpawnObject(PoolObjectType type)
    {
        GameObject ob = PoolManager.Instance.GetPoolObject(type);
        
        if (ob != null)
        {
            float randomZ= UnityEngine.Random.Range(-3f, 3f); 
            ob.transform.position = new Vector3(0f, 8.2f, randomZ); 
            ob.SetActive(true);
        }
    }

}

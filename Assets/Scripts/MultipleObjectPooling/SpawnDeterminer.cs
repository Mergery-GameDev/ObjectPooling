using System;
using System.Collections; // Required for IEnumerator
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeterminer : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 2f;

    void Start()
    {
        // Start the infinite spawning loop once at the beginning
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true) // Infinite loop for the game duration
        {
            // Pick a random type
            int random = UnityEngine.Random.Range(0, 2);
            PoolObjectType type = (random == 0) ? PoolObjectType.Cube : PoolObjectType.Cylinder;

            // Spawn the object
            SpawnObject(type);

            // Wait for a random interval (as you requested for your Flappy Bird game)
            float waitTime = UnityEngine.Random.Range(spawnInterval * 0.5f, spawnInterval * 1.5f);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void SpawnObject(PoolObjectType type)
    {
        GameObject ob = PoolManager.Instance.GetPoolObject(type);
        
        if (ob != null)
        {
            // Random Y position for Flappy Bird style obstacles
            //float randomY = UnityEngine.Random.Range(-3f, 3f); 
            ob.transform.position = new Vector3(0f, 8.2f, 0f); 
            ob.SetActive(true);
        }
    }
}

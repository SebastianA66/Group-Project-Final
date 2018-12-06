using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    public GameObject spawnee;

    public GameObject container;
    public GameObject potionContainer;

    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public int spawnLimit = 30;
    public int currentSpawnCount = 0;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);

        container = GameObject.Find("EnemyContainer");
        potionContainer = GameObject.Find("HealthContainer");
    }
    public void SpawnObject()
    {
        if (container.transform.childCount <= 20)
        {
            GameObject clone = Instantiate(spawnee, transform.position, transform.rotation);
            if (spawnee.name == "Enemy")
            {
                clone.transform.SetParent(container.transform);
            }
            else
            {
                clone.transform.SetParent(potionContainer.transform);
            }
            currentSpawnCount++;
        }
    }

    private void Update()
    {
        // When the enemies spawned reaches the spawn limit
        if (currentSpawnCount >= spawnLimit)
        { 
            // Stop spawning
            CancelInvoke("SpawnObject");
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour
{

    public GameObject objectToDrop;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public float dropHeight = 5.0f;
    public int spawnAmount = 10; // the number of objects to spawn
    public float dispersionAmount = 1.0f;


    // Vector3 dropPosition = new Vector3(0.0f, dropHeight, 0.0f);

    void Start() 
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.Space)){
            // Instantiate(objectToDrop, transform.position + dropPosition, Quaternion.identity);
            stopSpawning = !stopSpawning;
        }
    }

    public void SpawnObject(){
        Vector3 dropPosition = new Vector3(Random.Range(-dispersionAmount,dispersionAmount+1), dropHeight, Random.Range(-dispersionAmount,dispersionAmount+1));

        Instantiate(objectToDrop, transform.position + dropPosition, Quaternion.identity);

        if(stopSpawning) {
            CancelInvoke("SpawnObject");
        }
    }
}


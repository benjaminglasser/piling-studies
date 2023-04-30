using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDrop : MonoBehaviour
{

    public GameObject objectToDrop;
    public float dropHeight = 5.0f;
    public float dispersionRange = 1.0f;


    // Update is called once per frame
    void Update()
    {
        Vector3 dropPosition = new Vector3(Random.Range(-dispersionRange,dispersionRange + 1), dropHeight + Random.Range(-1,2), Random.Range(-dispersionRange,dispersionRange + 1));

        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(objectToDrop, transform.position + dropPosition, Quaternion.identity);
        }
    }
}

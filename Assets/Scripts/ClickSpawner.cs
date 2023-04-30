using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSpawner : MonoBehaviour
{

    public GameObject objectToDrop;


    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetMouseButtonDown(0)){

            Vector3 mousePosition = Input.mousePosition; // get mouse position
            mousePosition.z = Camera.main.nearClipPlane + 10; // set z position to camera's near clip plane
            
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(mousePosition); // convert mouse position to world coordinates
            Instantiate(objectToDrop, spawnPosition, Quaternion.identity);
        }
    }
}

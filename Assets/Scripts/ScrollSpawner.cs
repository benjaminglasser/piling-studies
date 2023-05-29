using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSpawner : MonoBehaviour
{
    public GameObject prefab; // prefab to be instantiated
    public float spawnHeight; // Height from where to instantiate prefab
    public float spawnRadius; // Radius of spawn area

    private Vector3 spawnPoint;
    private float previousScrollValue = 0; // Store previous scroll value
    public float maxSizeMultiplier = 1.5f;

    // Update is called once per frame
    void Update()
    {
        // Get the scroll wheel input
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scrollWheel) > float.Epsilon && previousScrollValue == 0)
        {
            SpawnObject();
            previousScrollValue = scrollWheel;
        }
        else if (Mathf.Abs(scrollWheel) == 0)
        {
            previousScrollValue = 0;
        }
    }

    void SpawnObject()
    {
        Vector2 circle = Random.insideUnitCircle * spawnRadius;
        spawnPoint = new Vector3(circle.x, spawnHeight, circle.y) + transform.position;

        Quaternion randomRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

        var newObj = Instantiate(prefab, spawnPoint, randomRotation);
        newObj.GetComponent<Rigidbody>().useGravity = true; // Assuming your prefab has a Rigidbody component

        float scaleMultiplier = Random.Range(1, maxSizeMultiplier);
        newObj.transform.localScale *= scaleMultiplier;
    }
}
using UnityEngine;

public class ClickSpawnerWColorHeight : MonoBehaviour
{
    public GameObject objectPrefab;
    public float thresholdHeight = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition; // get mouse position
            mousePosition.z = Camera.main.nearClipPlane + 10; // set z position to camera's near clip plane
            
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(mousePosition); // convert mouse position to world coordinates

            InstantiateObject(spawnPosition);
        }
    }

    private void InstantiateObject(Vector3 position)
    {
        
         // Generate a random rotation
        Quaternion randomRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        
        GameObject newObject = Instantiate(objectPrefab, position, randomRotation);
        DroppableObject droppableObject = newObject.AddComponent<DroppableObject>();
        

        droppableObject.shouldChangeColor = position.y >= thresholdHeight;
        newObject.AddComponent<Rigidbody>();


        // Add MeshCollider to the instantiated object
        MeshCollider meshCollider = newObject.AddComponent<MeshCollider>();
        MeshFilter meshFilter = newObject.GetComponent<MeshFilter>();
        meshCollider.convex = true;
    //     if (meshFilter != null)
    //     {
    //       meshCollider.sharedMesh = meshFilter.mesh;
    //       meshCollider.convex = true; // Set the MeshCollider to convex
    //     }
    //     else
    //     {
    //         Debug.LogWarning("No MeshFilter component found on the instantiated object. MeshCollider has been added but not assigned a mesh.");
    //  }

        // Assign the tag to the instantiated object
        newObject.tag = "Ground";
    
    }
}
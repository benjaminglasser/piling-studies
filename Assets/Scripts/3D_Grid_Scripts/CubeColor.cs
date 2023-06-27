using UnityEngine;

public class CubeColor : MonoBehaviour
{
    public Material[] emissionMaterials; // Assign your emission materials in Inspector

    private Material currentMaterial; // The current material

    void Start()
    {
        // Select a random material on start
        currentMaterial = emissionMaterials[Random.Range(0, emissionMaterials.Length)];
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is a sphere
        if (other.gameObject.CompareTag("Sphere")) 
        {
            // Change the material of the cube to the current material
            GetComponent<Renderer>().material = currentMaterial;
        }
    }
}
using UnityEngine;

public class CubeWhite : MonoBehaviour
{
    public Material emissionMaterial; // Assign a Material with emission color of white in Inspector

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is a sphere
        if (other.gameObject.CompareTag("Sphere")) 
        {
            // Change the material of the cube to the emission material
            GetComponent<Renderer>().material = emissionMaterial;
        }
    }
}
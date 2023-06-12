using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangingCube : MonoBehaviour
{
    public Material originalMaterial;
    public Material collisionMaterial;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material = originalMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _renderer.material = collisionMaterial;
    }
}

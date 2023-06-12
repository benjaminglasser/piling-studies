using UnityEngine;

public class ColorChangingCubeBoolean : MonoBehaviour
{
    public Material material1;
    public Material material2;

    private bool isMaterial1 = true;

    private Renderer rendererComponent;

    void Start()
    {
        rendererComponent = GetComponent<Renderer>();
        rendererComponent.material = material1;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isMaterial1)
        {
            rendererComponent.material = material2;
            isMaterial1 = false;
        }
        else
        {
            rendererComponent.material = material1;
            isMaterial1 = true;
        }
    }
}
using UnityEngine;

public class DroppableObject : MonoBehaviour
{
    public bool shouldChangeColor = false;

    private void ChangeColor(GameObject obj, Color color)
    {
        Renderer objRenderer = obj.GetComponent<Renderer>();
        objRenderer.material.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && shouldChangeColor)
        {
            ChangeColor(gameObject, Color.red);
        }
    }
}
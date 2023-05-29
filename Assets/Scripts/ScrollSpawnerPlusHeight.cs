using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollSpawnerPlusHeight : MonoBehaviour
{
    public GameObject prefab; // prefab to be instantiated
    public TextMeshProUGUI textPrefab; // Text prefab to be instantiated
    public Camera cameraToFace; // Camera for the text to face
    public float spawnHeight; // Height from where to instantiate prefab
    public float spawnRadius; // Radius of spawn area
    public float maxSizeMultiplier = 1.5f;

    private Vector3 spawnPoint;
    private float previousScrollValue = 0; // Store previous scroll value

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

        SpawnHeightText(newObj.transform);
    }

void SpawnHeightText(Transform objTransform)
{
    Vector3 textSpawnPoint = objTransform.position + Vector3.up * 2; // 2 units above the object

    // Create a new Canvas
    GameObject canvasObj = new GameObject("Canvas");
    Canvas canvas = canvasObj.AddComponent<Canvas>();
    canvas.renderMode = RenderMode.WorldSpace;
    CanvasScaler cs = canvasObj.AddComponent<CanvasScaler>();
    cs.scaleFactor = 10.0f;
    cs.dynamicPixelsPerUnit = 10f;
    GraphicRaycaster gr = canvasObj.AddComponent<GraphicRaycaster>();
    canvasObj.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 3.0f);
    canvasObj.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 3.0f);

    // Add a LineRenderer to the Canvas
    LineRenderer lr = canvasObj.AddComponent<LineRenderer>();
    lr.material = new Material(Shader.Find("Unlit/Color"));
    lr.material.color = Color.white;
    lr.startWidth = 0.01f;
    lr.endWidth = 0.01f;
    lr.positionCount = 2;

    // Instantiate the text as a child of the new Canvas
    var newText = Instantiate(textPrefab, canvas.transform, false);
    newText.transform.localPosition = Vector3.zero;
    newText.transform.localScale = Vector3.one; // Ensure the text has the correct scale

    // Position the Canvas at the object's location + 2 units upward
    canvasObj.transform.position = textSpawnPoint;

    StartCoroutine(UpdateHeightText(newText, objTransform, lr));
}

IEnumerator UpdateHeightText(TextMeshProUGUI textObj, Transform objTransform, LineRenderer line)
{
    while (true)
    {
        textObj.text = objTransform.position.y.ToString();

        // Update position of the canvas
        textObj.transform.parent.position = objTransform.position + Vector3.up * 2;

        // Make text always face the camera
        Vector3 direction = cameraToFace.transform.position - textObj.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        // We only want to rotate around the Y-axis, add 180 to flip the text
        textObj.transform.parent.rotation = Quaternion.Euler(0, rotation.eulerAngles.y + 180, 0);

        // Update the LineRenderer
        line.SetPosition(0, textObj.transform.parent.position);
        line.SetPosition(1, objTransform.position);

        yield return null; // Wait until next frame
    }
}
}
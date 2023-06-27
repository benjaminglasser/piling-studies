using UnityEngine;

public class GridGenerator_RT_Scroll_Grid : MonoBehaviour
{
    public GameObject cubePrefab; // Assign your Cube prefab in Inspector
    public Vector3 structureSize; // Overall size of the structure
    public Vector3Int subdivision; // Number of cubes in each dimension
    public int minRange = 1;
    public int maxRange = 5;

    public GameObject groundPlane; // The ground plane

    private Vector3Int lastSubdivision; // Stores the last subdivision to check for changes

    private void Start()
    {
        lastSubdivision = subdivision; // Initialize lastSubdivision
        GenerateGrid(); // Generate the grid once at the start
    }

    private void Update()
    {
        // Check for mouse wheel click
        if (Input.GetMouseButtonDown(2)) // Mouse scroll wheel clicked
        {
            SetRandom();
        }

        // Check if the subdivision has changed since the last frame
        if (subdivision != lastSubdivision)
        {
            // Clear the old grid
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            // Generate a new grid with the new subdivision
            GenerateGrid();

            // Update lastSubdivision to the new subdivision
            lastSubdivision = subdivision;
        }
    }

    private void SetRandom()
    {
        int randomValue = Random.Range(minRange, maxRange + 1);

        switch (Random.Range(0, 3))
        {
            case 0:
                subdivision.x = randomValue;
                break;
            case 1:
                subdivision.y = randomValue;
                break;
            case 2:
                subdivision.z = randomValue;
                break;
        }
    }

    private void GenerateGrid()
    {
        Vector3 cubeSize = new Vector3(structureSize.x / subdivision.x, structureSize.y / subdivision.y, structureSize.z / subdivision.z);

        for (int x = 0; x < subdivision.x; x++)
        {
            for (int y = 0; y < subdivision.y; y++)
            {
                for (int z = 0; z < subdivision.z; z++)
                {
                    // Compute position for this cube
                    Vector3 position = new Vector3(
                        (x + 0.5f) * cubeSize.x - structureSize.x / 2,
                        (y + 0.5f) * cubeSize.y - structureSize.y / 2,
                        (z + 0.5f) * cubeSize.z - structureSize.z / 2
                    );

                    // Instantiate cube at computed position and assign parent
                    GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
                    cube.transform.parent = this.transform;

                    // Resize the cube based on the calculated cube size
                    cube.transform.localScale = cubeSize;
                }
            }
        }

        // Instantiate the ground plane at the appropriate position
        Vector3 groundPosition = new Vector3(0, -structureSize.y / 2 - 0.5f, 0);
        GameObject ground = Instantiate(groundPlane, groundPosition, Quaternion.identity);
        ground.transform.parent = this.transform;

        // Resize the ground plane to match the x and z dimensions of the structure
        ground.transform.localScale = new Vector3(structureSize.x, 1, structureSize.z);
    }
}

using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject cubePrefab; // Assign your Cube prefab in Inspector
    public Vector3 structureSize; // Overall size of the structure
    public Vector3Int subdivision; // Number of cubes in each dimension

    public GameObject groundPlane; // The ground plane

    private void Start()
    {
        GenerateGrid();

        // Instantiate the ground plane at the appropriate position
        // Offset down by half the height of the ground cube
        Vector3 groundPosition = new Vector3(0, -structureSize.y / 2 - 0.5f, 0);
        GameObject ground = Instantiate(groundPlane, groundPosition, Quaternion.identity);
        ground.transform.parent = this.transform;

        // Resize the ground plane to match the x and z dimensions of the structure
        // and have a height of 1
        ground.transform.localScale = new Vector3(structureSize.x, 1, structureSize.z);
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
    }
}

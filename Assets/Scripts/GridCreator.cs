using UnityEngine;
using System.Collections.Generic;

public class GridCreator : MonoBehaviour
{
    public GameObject cubePrefab;
    public float gridSize = 10f;
    public int gridSubdivisions = 10;

    private List<GameObject> gridCubes = new List<GameObject>();

    private void Start()
    {
        CreateGrid();
    }

    public void CreateGrid()
    {
        // Delete existing cubes
        foreach (GameObject cube in gridCubes)
        {
            Destroy(cube);
        }
        gridCubes.Clear();

        // Calculate the size and spacing of each cube
        float cubeSize = gridSize / gridSubdivisions;

        // Offset to ensure the center of the grid is at (0, 0)
        float gridOffset = gridSize / 2;

        // Create new cubes
        for (int x = 0; x < gridSubdivisions; x++)
        {
            for (int z = 0; z < gridSubdivisions; z++)
            {
                Vector3 cubePosition = new Vector3(x * cubeSize - gridOffset + cubeSize / 2, 0, z * cubeSize - gridOffset + cubeSize / 2);
                GameObject newCube = Instantiate(cubePrefab, cubePosition, Quaternion.identity, transform);
                newCube.transform.localScale = new Vector3(cubeSize, newCube.transform.localScale.y, cubeSize);
                gridCubes.Add(newCube);
            }
        }
    }
}

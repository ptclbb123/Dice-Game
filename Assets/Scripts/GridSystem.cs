using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private int gridSizeX = 10; // Number of grid cells in the X direction
    [SerializeField] private int gridSizeY = 10; // Number of grid cells in the Y direction
    [SerializeField] private Transform gridOrigin;
    [SerializeField] private GameObject gridTilePrefab; // Prefab for the grid tile

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        // Get the position of the grid origin
        Vector3 originPosition = gridOrigin.position;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                // Calculate position for each tile based on the grid origin
                Vector3 tilePosition = new Vector3(originPosition.x + x, originPosition.y + y, originPosition.z + 5);
                GameObject gridTile = Instantiate(gridTilePrefab, tilePosition, Quaternion.identity);
                gridTile.name = "(" + x + "," + y + ")";
                gridTile.transform.parent = gridOrigin.transform; // Set the grid tile as a child of the grid system
            }
        }
    }
}
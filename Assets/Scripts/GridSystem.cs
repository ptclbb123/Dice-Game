#region old code

using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private int gridSizeX = 10; // Number of grid cells in the X direction
    [SerializeField] private int gridSizeY = 10; // Number of grid cells in the Y direction
    [SerializeField] private Transform gridOrigin;
    [SerializeField] private GameObject gridTilePrefab; // Prefab for the grid tile
    [SerializeField] private GameObject wallPrefab; // Prefab for the wall
    [SerializeField] private GameObject boundaryWallPrefab;
    [SerializeField] private Transform wallSpawnPoint;
    [SerializeField] private Transform wallParentObject;

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
                //   Calculate position for each tile based on the grid origin

                Vector3 tilePosition = new Vector3(originPosition.x + x, originPosition.y + y, originPosition.z + 5);
                GameObject gridTile = Instantiate(gridTilePrefab, tilePosition, Quaternion.identity);
                gridTile.name = "(" + x + "," + y + ")";
                gridTile.transform.parent = gridOrigin.transform;

                //  Check if the current position is at the border of the map
                if (x == 0 || x == gridSizeX - 1 || y == 0 || y == gridSizeY - 1)
                {
                    // Instantiate a wall at the border position
                    InstantiateBoundaryWall(x, y);
                }
                //  Check if the current position is in an even row and column(checkerboard pattern)
                else if (x % 2 == 0 && y % 2 == 0)
                {
                    //  Instantiate a wall at the even position
                    InstantiateRegularWall(x, y);
                }
            }
        }
    }

    private void InstantiateBoundaryWall(int x, int y)
    {
        //        Use the position of the wall spawn point for positioning the wall

        Vector3 wallPosition = wallSpawnPoint.position + new Vector3(x, y, 0);
        GameObject boundaryWall = Instantiate(boundaryWallPrefab, wallPosition, Quaternion.identity);
        boundaryWall.transform.parent = wallParentObject.transform;
    }

    private void InstantiateRegularWall(int x, int y)
    {
        //  Use the position of the wall spawn point for positioning the wall

        Vector3 wallPosition = wallSpawnPoint.position + new Vector3(x, y, 0);
        GameObject regularWall = Instantiate(wallPrefab, new Vector2(wallPosition.x, wallPosition.y + 1), Quaternion.identity);
        regularWall.transform.parent = wallParentObject.transform;
    }
}

#endregion old code
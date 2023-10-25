using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    [SerializeField] private int rows = 5;
    [SerializeField] private int cols = 5;
    [SerializeField] private float tileSize = 1;
    [SerializeField] private GameObject go;

    // Start is called before the first frame update
    private void Start()
    {
        GenerateGridNow();
    }

    private void GenerateGridNow()
    {
        GameObject tileReference = Instantiate(go);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; i++)
            {
                GameObject tile = Instantiate(tileReference, this.transform);
                float posX = j * tileSize;
                float posY = i * -tileSize;
                tile.transform.position = new Vector2(posX, posY);
            }
        }

        Destroy(tileReference);
        float gridW = cols * tileSize;
        float gridH = rows * tileSize;
        this.transform.position = new Vector2(gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);
    }
}
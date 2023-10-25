using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridArray : MonoBehaviour
{
    [SerializeField] private float[,] grid;
    [SerializeField] private int vertical;
    [SerializeField] private int horizontal;
    [SerializeField] private int coloums;
    [SerializeField] private int rows;
    [SerializeField] private Sprite sprit;

    // Start is called before the first frame update
    private void Start()
    {
        vertical = (int)Camera.main.orthographicSize;
        horizontal = vertical * (Screen.width / Screen.height);
        coloums = horizontal * 2;
        rows = vertical * 2;
        grid = new float[coloums, rows];

        for (int i = 0; i < coloums; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                grid[i, j] = Random.Range(0.0f, 2.0f);
                SpawnTile(i, j, grid[i, j]);
            }
        }
    }

    private void SpawnTile(int x, int y, float value)
    {
        GameObject g = new GameObject("X: " + x + " Y: " + y);
        g.transform.position = new Vector2(x - (horizontal - .5f), y - (vertical - .5f));
        var r = g.gameObject.AddComponent<SpriteRenderer>();
        r.sprite = sprit;
        r.color = new Color(value, value, value);
        g.transform.SetParent(this.transform.parent);
    }
}
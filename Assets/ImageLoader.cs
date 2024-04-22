using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    // Define a public field for the linked list
    public LinkedList<Sprite> capturedImagesList;

    // Reference to the Image component where the images will be displayed
    public Image imageDisplay;

    // Method to load stored data and populate the linked list
    public void LoadImages()
    {
        capturedImagesList = new LinkedList<Sprite>();
        // Clear the existing linked list
        capturedImagesList.Clear();

        // Retrieve the total count of stored images
        int imageCount = PlayerPrefs.GetInt("CURRENT_DAY", 1);

        // Iterate through the stored images and load them as sprites
        for (int i = 1; i <= imageCount; i++)
        {
            // Retrieve the file path of the stored image
            string imagePath = PlayerPrefs.GetString("ImagePath" + i);

            // Load the image from the file path and create a sprite
            Texture2D texture = LoadTextureFromFile(imagePath);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

            // Add the sprite to the linked list
            capturedImagesList.AddLast(sprite);
        }

        // Display the first image in the Image component, if available
        if (capturedImagesList.Count > 0)
        {
            imageDisplay.sprite = capturedImagesList.First.Value;
        }
    }

    // Method to load a texture from file
    private Texture2D LoadTextureFromFile(string path)
    {
        byte[] fileData = System.IO.File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData);
        return texture;
    }
}
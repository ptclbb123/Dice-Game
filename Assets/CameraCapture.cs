using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraCapture : MonoBehaviour
{
    public Image capturedImage;

    public void CaptureImage()
    {
        disappearItem_BeforeCaptureing();
        int imageDayId = PlayerPrefs.GetInt("CURRENT_DAY");
        string screenshotPath = Application.persistentDataPath + "/screenshot" + imageDayId + ".png";
        ScreenCapture.CaptureScreenshot(screenshotPath);
        PlayerPrefs.SetString("ImagePath" + imageDayId, screenshotPath);
        PlayerPrefs.SetInt("ImageCount", imageDayId);
        StartCoroutine(LoadSprite(screenshotPath));
    }

    private void disappearItem_BeforeCaptureing()
    {
    }

    private void appearItem_AfterCaptureing()
    {
    }

    private IEnumerator LoadSprite(string path)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        appearItem_AfterCaptureing();

        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.filterMode = FilterMode.Trilinear;
        byte[] fileData = File.ReadAllBytes(path);
        texture.LoadImage(fileData);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        capturedImage.sprite = sprite;

        // ImageManager.Instance.AddCapturedImage(sprite);
    }
}
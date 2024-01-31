using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePhoto : MonoBehaviour
{
    [SerializeField]
    RenderCapturer capturer;

    /// <summary>
    /// Initiates the process of capturing a screenshot and saving it to the gallery.
    /// </summary>
    public void TakeScreenshot()
    {
        StartCoroutine(TakeScreenshotAndSave());
    }

    /// <summary>
    /// Coroutine that introduces a small delay before capturing a screenshot and saving it to the gallery.
    /// </summary>
    private IEnumerator TakeScreenshotAndSave()
    {
        yield return new WaitForSeconds(.1f);
        byte[] bytes = capturer.GetScreenCaptureImage();
        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(bytes, "GalleryTest", "Image.png", (success, path) => Debug.Log("Media save result: " + success + " " + path));

        Debug.Log("Permission result: " + permission);
    }
}

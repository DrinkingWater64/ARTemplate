using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class RenderCapturer : MonoBehaviour
{
    private RenderTexture rt;
    byte[] RawImageBytes;
    Camera _camera;
    /// <summary>
    /// Captures the image from the main camera's render texture.
    /// </summary>
    void getCameraImage()
    {
        var w = Screen.width;
        var h = Screen.height;

        _camera = Camera.main;

        // Create a new render texture
        rt = new RenderTexture(w, h, 24);
        _camera.targetTexture = rt;

        // Store the current render texture and set the camera to render to the new texture
        var currentRT = RenderTexture.active;
        RenderTexture.active = rt;

        _camera.Render();

        // Read the pixels from the render texture into a 2D texture
        Texture2D image = new Texture2D(w,h, TextureFormat.ARGB32, false);
        image.ReadPixels(new Rect(0, 0, w, h), 0, 0);
        image.Apply();

        // Reset the camera's target texture
        _camera.targetTexture = null;

        // Restore the original render texture
        RenderTexture.active = currentRT;

        RawImageBytes = image.EncodeToPNG();
        Destroy( rt );
        Destroy( image );
    }

    IEnumerator RenderProcess()
    {
        yield return new WaitForSeconds(.01f);
        getCameraImage();
        yield return new WaitForSeconds(.1f);

    }

    public byte[] GetScreenCaptureImage()
    {
        StartCoroutine(RenderProcess());
        return RawImageBytes;
    }


}

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

    void getCameraImage()
    {
        var w = Screen.width;
        var h = Screen.height;
        _camera = Camera.main;
        rt = new RenderTexture(w, h, 24);
        _camera.targetTexture = rt;
        
        var currentRT = RenderTexture.active;
        RenderTexture.active = rt;

        _camera.Render();

        Texture2D image = new Texture2D(w,h, TextureFormat.ARGB32, false);
        image.ReadPixels(new Rect(0, 0, w, h), 0, 0);
        image.Apply();

        _camera.targetTexture = null;

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

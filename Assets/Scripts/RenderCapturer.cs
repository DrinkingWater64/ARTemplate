using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class RenderCapturer : MonoBehaviour
{
    public RenderTexture RT;
    public GameObject RenderCamera;
    public RawImage RawImage;
    byte[] RawImageBytes;
    void getImage()
    {
        Texture2D texture = new Texture2D(RT.width, RT.height, TextureFormat.ARGB32, false);
        RenderTexture.active = RT;
        texture.ReadPixels(new Rect(0, 0, RT.width, RT.height), 0, 0);

        RawImageBytes = texture.EncodeToPNG();
    }

    IEnumerator RenderProcess()
    {
        RenderCamera.SetActive(true);
        yield return new WaitForSeconds(.01f);
        getImage();
        yield return new WaitForSeconds(.1f);
        RenderCamera.SetActive(false);

    }

    public byte[] GetScreenCaptureImage()
    {
        StartCoroutine(RenderProcess());
        return RawImageBytes;
    }


}

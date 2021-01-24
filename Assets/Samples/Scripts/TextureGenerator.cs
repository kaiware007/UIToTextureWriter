using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureGenerator : MonoBehaviour
{
    public int width;
    public int height;
    public string globalTexName = "";
    public RenderTexture rt;
    [SerializeField]
    RawImage image = null;

    public RenderTexture Generate(int widht, int height, string globalTexName)
    {
        var t = new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32);
        t.enableRandomWrite = true;
        t.Create();
        return t;
    }

    // Start is called before the first frame update
    void Start()
    {
        rt = Generate(width, height, globalTexName);
        Shader.SetGlobalTexture(globalTexName, rt);

        image.texture = rt;
    }
}

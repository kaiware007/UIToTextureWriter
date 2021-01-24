using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureWriter : MonoBehaviour
{
    protected int x;
    protected int y;
    protected int width = 4;
    protected int height = 4;
    protected Color color = Color.black;
    public bool isReqUpdate = false;
    public RenderTexture targetTexture = null;

    [SerializeField]
    protected ComputeShader cs = null;

    [SerializeField]
    protected string globalTextureName = "_ControlTex";

    public virtual void SetColor(int x, int y, int w, int h, Color col)
    {
        this.x = x;
        this.y = y;
        this.width = w;
        this.height = h;
        this.color = col;
        this.isReqUpdate = true;
    }

    protected virtual void WriteTextureInternal(int xx, int yy, int ww, int hh, Color col)
    {
        var kernelIndex = cs.FindKernel("CSMain");

        uint xnum, ynum, znum;
        cs.GetKernelThreadGroupSizes(kernelIndex, out xnum, out ynum, out znum);

        cs.SetInt("_X", xx);
        cs.SetInt("_Y", yy);
        cs.SetInt("_W", ww);
        cs.SetInt("_H", hh);
        cs.SetVector("_Color", col);
        if (targetTexture != null)
        {
            cs.SetTexture(kernelIndex, "_Dest", targetTexture);
        }
        else
        {
            cs.SetTextureFromGlobal(kernelIndex, "_Dest", globalTextureName);
        }
        cs.Dispatch(kernelIndex, Mathf.CeilToInt((float)ww / xnum), Mathf.CeilToInt((float)hh / ynum), 1);

    }

    protected virtual void WriteTexture()
    {
        WriteTextureInternal(x, y, width, height, color);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isReqUpdate && cs != null)
        {
            WriteTexture();
            isReqUpdate = false;
        }
    }
}

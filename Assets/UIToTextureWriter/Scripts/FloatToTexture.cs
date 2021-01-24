using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatToTexture : UIToTextureBase<float>
{
    public bool isEveryUpdate = false;
        
    protected override void Initialize()
    {
        var slider = GetComponent<Slider>();
        if (slider != null)
        {
            OnValueChanged(slider.value);
        }
    }

    public override void OnValueChanged(float v)
    {
        isChange = true;

        value = v;
        color = v * baseColor;
    }

    protected override void UpdateColor()
    {
        if (isChange || isEveryUpdate)
        {
            isChange = false;

            tw.SetColor(x, y, width, height, color);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoolToTexture : UIToTextureBase<bool>
{
    protected override void Initialize()
    {
        var toggle = GetComponent<Toggle>();
        if(toggle != null)
        {
            OnValueChanged(toggle.isOn);
        }
    }

    public override void OnValueChanged(bool b)
    {
        isChange = true;

        value = b;
        color = b ? baseColor : Color.black;
    }

    protected override void UpdateColor()
    {
        if (isChange)
        {
            isChange = false;

            tw.SetColor(x, y, width, height, color);
        }
    }
}

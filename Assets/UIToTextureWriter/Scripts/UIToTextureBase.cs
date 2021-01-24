using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIToTextureBase<T> : MonoBehaviour
{
    public T value;
    
    public int x, y, width, height;
    public Color baseColor = Color.white;
    public Color color;

    [SerializeField]
    protected TextureWriter tw;

    protected bool isChange = false;

    public abstract void OnValueChanged(T b);

    protected virtual void Initialize()
    {

    }

    protected virtual void UpdateColor()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();    
    }

    // Update is called once per frame
    void Update()
    {
        UpdateColor();
    }
}

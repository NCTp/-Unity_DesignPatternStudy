using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Light : Observer
{
    public Color lightColor = Color.red;
    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;
    private bool _isLightOn = false;
    public override void Notify(Subject subject)
    {
        Debug.Log(this.name + " is Notified!");
        if(_spriteRenderer != null)
        {
            if(!_isLightOn)
            {
                _spriteRenderer.color = lightColor;
                _isLightOn = true;
            }
            else
            {
                _spriteRenderer.color = _originalColor;
                _isLightOn = false;
            }

        }
  
    }

    
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

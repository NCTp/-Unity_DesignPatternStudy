using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackGround : MonoBehaviour
{
    public float scrollSpeed = 1.0f;
    public float backgroundWidth;
    private float screenWidth;
    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        Debug.Log(screenWidth * 2);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);
        
        if(transform.position.x < -backgroundWidth)
        {
            transform.position = new Vector2(backgroundWidth, transform.position.y);
        }
        
    }
}

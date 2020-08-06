using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector3 vector3 = transform.localScale; // lay scale hien tai cua MainScrean
        float imageWidth = spriteRenderer.bounds.size.x;
        float imageHeight = spriteRenderer.bounds.size.y;

        float screenHeight = Camera.main.orthographicSize * 2f;
        float screenWidth = screenHeight * Screen.width / Screen.height;

        vector3.x = screenWidth / imageWidth;
        vector3.y = screenHeight / imageHeight;

        transform.localScale = vector3;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

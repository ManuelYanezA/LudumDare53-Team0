using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private BoxCollider2D cameraBox;
    private Transform player;

    void Start()
    {
        cameraBox = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Robot").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AspectRatioBoxChange()
    {
        if(Camera.main.aspect >= (1.6f) && Camera.main.aspect < 1.7f)
        {
            cameraBox.size = new Vector2(23,14.3f);
        }
        if(Camera.main.aspect >= (1.7f) && Camera.main.aspect < (1.8f))
        {
            cameraBox.size = new Vector2(25.47f, 14.3f);
        }
        //if (Camera.main.aspect >= (1.25f) && Camera.main.aspect < ())
        
    }

}

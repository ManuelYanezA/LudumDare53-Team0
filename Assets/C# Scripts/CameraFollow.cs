using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private BoxCollider2D cameraBox;
    private Transform player;
    //private float boundaryMargin = 1.5f;

    void Start()
    {
        cameraBox = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        AspectRatioBoxChange();
        FollowPlayer();

    }

    void AspectRatioBoxChange()
    {
        if (Camera.main.aspect >= (1.6f) && Camera.main.aspect < 1.7f)
        {
            cameraBox.size = new Vector2(23, 14.3f);
        }
        if (Camera.main.aspect >= (1.7f) && Camera.main.aspect < (1.8f))
        {
            cameraBox.size = new Vector2(25.47f, 14.3f);
        }
        if (Camera.main.aspect >= (1.25f) && Camera.main.aspect < (1.3f))
        {
            cameraBox.size = new Vector2(18f, 14.3f);
        }
        if (Camera.main.aspect >= (1.3f) && Camera.main.aspect < 1.4f)
        {
            cameraBox.size = new Vector2(19.13f, 14.3f);
        }
        if (Camera.main.aspect >= (1.5) && Camera.main.aspect < 1.6f)
        {
            cameraBox.size = new Vector2(21.6f, 14.3f);
        }
        //float cameraH = (Camera.main.orthographicSize * 2) + 0.1f;

        //float cameraW = (Camera.main.orthographicSize * Camera.main.aspect * 2) + 0.1f;

        //cameraBox.size = new Vector2(cameraW, cameraH);

    }

    void FollowPlayer()
    {

        if(GameObject.Find("Boundary"))
        {
            transform.position = new Vector3(Mathf.Clamp(player.position.x, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.x + cameraBox.size.x / 2, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.x - cameraBox.size.x / 2),
                                            Mathf.Clamp(player.position.y, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.y + cameraBox.size.y / 2, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.y - cameraBox.size.y / 2),
                                            transform.position.z);
        }

        //if (GameObject.Find("Boundary"))
        //{
        //
        //    Bounds boundaryBounds = GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds;
        //    float cameraHeight = cameraBox.size.y;
        //    float cameraWidth = cameraBox.size.x;
        //
        //    float minX = boundaryBounds.min.x + cameraWidth / 2 + boundaryMargin;
        //    float maxX = boundaryBounds.max.x - cameraWidth / 2 - boundaryMargin;
        //    float minY = boundaryBounds.min.y + cameraHeight / 2 + boundaryMargin;
        //    float maxY = boundaryBounds.max.y - cameraHeight / 2 - boundaryMargin;
        //
        //    Debug.Log("minX: " + minX + " maxX: " + maxX + " minY: " + minY + " maxY: " + maxY);
        //
        //    float clampedX = Mathf.Clamp(player.position.x, minX, maxX);
        //    float clampedY = Mathf.Clamp(player.position.y, minY, maxY);
        //
        //    transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        //}
    }


}
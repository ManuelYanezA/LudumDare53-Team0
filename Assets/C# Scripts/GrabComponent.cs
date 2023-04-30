using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class GrabComponent : MonoBehaviour
{
    public Transform GrabDetected;
    public Transform Holder;
    [SerializeField] public float RayDist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D grabCheck = Physics2D.Raycast(GrabDetected.position, Vector2.right * transform.localScale, RayDist);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            if (Input.GetKey(KeyCode.E))
            {
                grabCheck.collider.gameObject.transform.parent = Holder;
                grabCheck.collider.gameObject.transform.position = Holder.position;

            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;

            }
        }

    }
}

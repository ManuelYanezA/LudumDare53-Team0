using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamma2Movement : MonoBehaviour, IControllable
{
    public Controller Controller { get; set; }

    [SerializeField] private bool _beingControlled = false;
    //private bool _turretMode = false;

    [SerializeField] private float speed = 7f;
    [SerializeField] private float direction = 0f;

    private Rigidbody2D rb;

    //From interface
    public void OnControlStart()
    {
        _beingControlled = true;
    }

    //From interface
    public void OnControlEnd()
    {
        _beingControlled = false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_beingControlled)
        {
            //Controls
            direction = Input.GetAxis("Vertical");

            if(direction > 0f)
            {
                //Right movement
                rb.velocity = new Vector2(rb.velocity.x, direction * speed);
            }
            else if(direction < 0f)
            {
                //Left movement
                rb.velocity = new Vector2(rb.velocity.x, direction * speed);
            } else 
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaMovement : MonoBehaviour, IControllable
{
    public Controller Controller { get; set; }

    private bool _beingControlled = false;
    private bool _turretMode = false;

    [SerializeField] private float speed = 2.5f;
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
            direction = Input.GetAxis("Horizontal");

            if(direction > 0f)
            {
                //Right movement
                rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            }
            else if(direction < 0f)
            {
                //Left movement
                rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            } else 
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaMovement : MonoBehaviour, IControllable
{
    public Controller Controller { get; set; }

    [SerializeField] private bool _beingControlled = false;
    private bool _turretMode = false;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float direction = 0f;

    [SerializeField] private float jumpSpeed = 8f;

    public Transform groundCheck;
    public float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isTouchingGround;

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
            isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            direction = Input.GetAxis("Horizontal");

            if(direction > 0f)
            {
                //Right movement
                rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            }
            else if(direction < 0f)
            {
                ////Left movement
                rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            } else 
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
            }

            if(Input.GetButtonDown("Jump") && isTouchingGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
}

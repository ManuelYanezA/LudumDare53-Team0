using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaMovement : MonoBehaviour, IControllable
{
    public Controller Controller { get; set; }

    [SerializeField] private bool _beingControlled = false;
    //private bool _turretMode = false;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float direction = 0f;

    [SerializeField] private float jumpSpeed = 8f;

    public Transform groundCheck;
    public float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isTouchingGround;

    [SerializeField] private float projectileSpeed = 5f;
    public GameObject projectilePrefab;
    private Vector3 batteryDirection;

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

        if (_beingControlled)
        {

            //Controls
            isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            direction = Input.GetAxis("Horizontal");

            if(isTouchingGround && Input.GetKey(KeyCode.V))
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
                //If the V Key (Or other key defined up here) is being held, the player does not move
                if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    //Player shoots a projectile in a selected direction
                    batteryDirection = new Vector3(-1f,0f,0f);
                    GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                    projectile.GetComponent<Rigidbody2D>().velocity = batteryDirection * projectileSpeed;
                    batteryDirection = Vector3.zero;
                }
                else if((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    //Player shoots a projectile in a selected direction
                    batteryDirection = new Vector3(1f,0f,0f);
                    GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                    projectile.GetComponent<Rigidbody2D>().velocity = batteryDirection * projectileSpeed;
                    batteryDirection = Vector3.zero;
                }
                else if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
                {
                    //Player shoots a projectile in a selected direction
                    batteryDirection = new Vector3(0f,1f,0f);
                    GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                    projectile.GetComponent<Rigidbody2D>().velocity = batteryDirection * projectileSpeed;
                    batteryDirection = Vector3.zero;
                }
            }
            else
            {
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
                    //Idle
                    rb.velocity = new Vector2(0f, rb.velocity.y);
                }

                if(Input.GetButtonDown("Jump") && isTouchingGround)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                }
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
}

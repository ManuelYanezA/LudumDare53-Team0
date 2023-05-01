using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaMovement : MonoBehaviour, IControllable
{
    public Controller Controller { get; set; }
    private IControllable _controllable;

    public float maxHealth = 10f;
    private float currentHealth;

    [SerializeField] private bool _beingControlled = false;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float direction = 0f;

    [SerializeField] private float jumpSpeed = 8f;

    public Transform groundCheck;
    public float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask robotLayer;
    [SerializeField] private bool isTouchingGround;
    [SerializeField] private bool isTouchingRobot;

    [SerializeField] private float projectileSpeed = 5f;
    public GameObject projectilePrefab;
    private Vector3 batteryDirection;

    private Rigidbody2D rb;
    int alphaLayer;

    //From interface
    public void OnControlStart()
    {
        _beingControlled = true;
        gameObject.tag = "Player";
        alphaLayer = LayerMask.NameToLayer("Player");
        gameObject.layer = alphaLayer;
    }

    //From interface
    public void OnControlEnd()
    {
        _beingControlled = false;
        gameObject.tag = "Robot";
        alphaLayer = LayerMask.NameToLayer("Robot");
        gameObject.layer = alphaLayer;
    }

    void Awake()
    {
        _controllable = GetComponent<IControllable>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (_beingControlled)
        {

            //Controls
            isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            isTouchingRobot = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, robotLayer);
            direction = Input.GetAxis("Horizontal");

            if((isTouchingGround || isTouchingRobot) && Input.GetKey(KeyCode.V))
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
                //If the V Key (Or other key defined up here) is being held, the player does not move
                if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    //Player shoots a projectile in a selected direction
                    batteryDirection = new Vector3(-1f,0f,0f);
                    Vector3 spawnPosition = transform.position + new Vector3(-0.75f,0f,0f);
                    GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
                    projectile.GetComponent<Rigidbody2D>().velocity = batteryDirection * projectileSpeed;
                    batteryDirection = Vector3.zero;
                    if(_controllable.Controller != null)
                    {
                        if(projectile.GetComponent<IControllable>() != null)
                        {
                            _controllable.Controller.TakeControl(projectile);
                        }
                    }
                }
                else if((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    //Player shoots a projectile in a selected direction
                    batteryDirection = new Vector3(1f,0f,0f);
                    Vector3 spawnPosition = transform.position + new Vector3(0.75f,0f,0f);
                    GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
                    projectile.GetComponent<Rigidbody2D>().velocity = batteryDirection * projectileSpeed;
                    batteryDirection = Vector3.zero;
                    if(_controllable.Controller != null)
                    {
                        if(projectile.GetComponent<IControllable>() != null)
                        {
                            _controllable.Controller.TakeControl(projectile);
                        }
                    }
                }
                else if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
                {
                    //Player shoots a projectile in a selected direction
                    batteryDirection = new Vector3(0f,1f,0f);
                    Vector3 spawnPosition = transform.position + new Vector3(0f,0.75f,0f);
                    GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
                    projectile.GetComponent<Rigidbody2D>().velocity = batteryDirection * projectileSpeed;
                    batteryDirection = Vector3.zero;
                    if(_controllable.Controller != null)
                    {
                        if(projectile.GetComponent<IControllable>() != null)
                        {
                            _controllable.Controller.TakeControl(projectile);
                        }
                    }
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

                if(Input.GetButtonDown("Jump") && (isTouchingGround || isTouchingRobot))
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

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }

}

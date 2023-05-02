using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphaMovement : MonoBehaviour, IControllable
{
    public Controller Controller { get; set; }
    private IControllable _controllable;
    Animator ani;
    SpriteRenderer sr;
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
        ani = GetComponent<Animator>();
        sr=GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        ani.SetBool("isAlive", false);
        if (_beingControlled)
        {
            ani.SetBool("isAlive", true);
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
                    ani.SetBool("Walking", false);
                    ani.SetBool("ShootF", true);
                    
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
                    ani.SetBool("Walking", false);
                    ani.SetBool("ShootF", true);
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
                    ani.SetBool("Walking", false);
                    ani.SetBool("ShootUp", true);
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
                    sr.flipX = false;
                    ani.SetBool("ShootF", false);
                    ani.SetBool("ShootUp", false);
                    ani.SetBool("Walking", true);
                    //Right movement
                    rb.velocity = new Vector2(direction * speed, rb.velocity.y);
                }
                else if(direction < 0f)
                {
                    sr.flipX = true;
                    ani.SetBool("ShootF", false);
                    ani.SetBool("ShootUp", false);
                    ani.SetBool("Walking", true);
                    //Left movement
                    rb.velocity = new Vector2(direction * speed, rb.velocity.y);
                } else 
                {
                    ani.SetBool("ShootF", false);
                    ani.SetBool("ShootUp", false);
                    ani.SetBool("Walking", false);
                    //Idle
                    rb.velocity = new Vector2(0f, rb.velocity.y);
                }

                if(Input.GetButtonDown("Jump") && (isTouchingGround || isTouchingRobot))
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                }
                if (!isTouchingGround && !isTouchingRobot)
                {
                    ani.SetBool("ShootUp", false);
                    ani.SetBool("ShootF", false);
                    ani.SetBool("Walking", false);
                    ani.SetBool("Air", true);
                }
                else
                {
                    ani.SetBool("Air", false);
                }
            }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

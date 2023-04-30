using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaMovement : MonoBehaviour, IControllable
{
    public Controller Controller { get; set; }
    private IControllable _controllable;

    [SerializeField] private bool _beingControlled = false;
    //private bool _turretMode = false;

    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float direction = 0f;

    private Rigidbody2D rb;
    private Vector3 batteryDirection;
    [SerializeField] private float projectileSpeed = 5f;
    public GameObject projectilePrefab;

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

    void Awake()
    {
        _controllable = GetComponent<IControllable>();
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

            if(Input.GetKey(KeyCode.V))
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
                //If the V Key (Or other key defined up here) is being held, the player does not move
                if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    //Player shoots a projectile in a selected direction
                    batteryDirection = new Vector3(-1f,0f,0f);
                    Vector3 spawnPosition = transform.position + new Vector3(-1.1f,0f,0f);
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
                    Vector3 spawnPosition = transform.position + new Vector3(1.1f,0f,0f);
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
                    Vector3 spawnPosition = transform.position + new Vector3(0f,1.1f,0f);
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
            }
        }
    }
}

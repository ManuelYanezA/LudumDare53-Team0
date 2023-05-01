using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour, IControllable
{
    public Controller Controller { get; set; }
    private IControllable _controllable;

    [SerializeField] private bool _beingControlled = false;
    private Rigidbody2D rb;

    //From interface
    public void OnControlStart()
    {
        _beingControlled = true;
        gameObject.tag = "Player";
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _controllable = GetComponent<IControllable>();
    }

    //From interface
    public void OnControlEnd()
    {
        _beingControlled = false;
        gameObject.tag = "Battery";
    }

    // Update is called once per frame
    void Update()
    {
        if(_beingControlled)
        {
            //Controls
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Terrain"))
        {
            //Moves to the opposite direction if Battery collisions with a "Terrain" tagged object
            rb.velocity *= -1f;
        }
        if(other.gameObject.CompareTag("Robot"))
        {
            //Takes control of the collided robot
            //If this object is currently being controlled
            if(_controllable.Controller != null)
            {
                //If the object collisioned is controllable
                if(other.GetComponent<IControllable>() != null)
                {
                    //Tell this object's controller to take control of the collisiones object
                    _controllable.Controller.TakeControl(other.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour, IControllable
{
    public Controller Controller { get; set; }

    [SerializeField] private bool _beingControlled = false;
    private Rigidbody2D rb;

    //From interface
    public void OnControlStart()
    {
        _beingControlled = true;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //From interface
    public void OnControlEnd()
    {
        _beingControlled = false;
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
    }
}

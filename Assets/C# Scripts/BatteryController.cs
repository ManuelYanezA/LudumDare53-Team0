using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour, IControllable
{
    public Controller Controller { get; set; }

    [SerializeField] private bool _beingControlled = false;

    //From interface
    public void OnControlStart()
    {
        _beingControlled = false;
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, IControllable
{
    //Part of interface, assigned by Controller
    public Controller Controller { get; set; }

    private bool _beingControlled = false;

    //Part of interface, called by controller
    public void OnControlStart()
    {
        _beingControlled = true;
    }

    //Part of interface, called by controller
    public void OnControlEnd()
    {
        _beingControlled = false;
    }

    private void Update()
    {
        if(_beingControlled)
        {
            //Controles
        }
    }
}

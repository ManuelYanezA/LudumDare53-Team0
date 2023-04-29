using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlOnColission : MonoBehaviour
{
    private IControllable _controllable;

    private void Awake()
    {
        _controllable = GetComponent<IControllable>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If this object is currently being controlled
        if(_controllable.Controller != null)
        {
            //If the trigger we entered is on an object that is controllable
            if(other.GetComponent<IControllable>() != null)
            {
                //Tell this object's controller to take control of it
                _controllable.Controller.TakeControl(other.gameObject);
            }
        }
    }
}

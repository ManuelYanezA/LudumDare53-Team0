using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //Controller functions as a Controller Manager, it must be in a empty object so it manages multiple controllable objects
    // optionally take control of something right at the start
    [SerializeField] private GameObject _controlAtStart;
 
    // the currently controlled object
    public IControllable CurrentTarget { get; private set; }
 
    private void Start()
    {
        if (_controlAtStart != null)
        {
            TakeControl(_controlAtStart);
        }
    }
 
    public void TakeControl(GameObject controllableObject)
    {
        IControllable controllable = controllableObject.GetComponent<IControllable>();
        if (controllable != null)
        {
            // release control of the current object before controlling the new one
            ReleaseControl();
 
            // assign the new target
            CurrentTarget = controllable;
            // tell it it's being controlled now (by this controller)
            CurrentTarget.Controller = this;
            CurrentTarget.OnControlStart();
 
            //Debug.LogFormat("Now controlling {0}", controllable.gameObject.name);
        }
    }
 
    public void ReleaseControl()
    {
        // if there is something to release control of
        if (CurrentTarget != null)
        {
            // tell it it's no longer being controlled and clear the reference to it
            CurrentTarget.OnControlEnd();
            CurrentTarget.Controller = null;
            CurrentTarget = null;
        }
    }
}


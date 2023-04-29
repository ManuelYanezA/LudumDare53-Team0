using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable
{
    GameObject gameObject { get; } // monobehaviours already implmement this by default
 
    // these must be implemented by the controllable object
    Controller Controller { get; set; }
    void OnControlStart();
    void OnControlEnd();
}


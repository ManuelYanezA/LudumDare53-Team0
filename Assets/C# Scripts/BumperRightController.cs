using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperRightController : MonoBehaviour
{
    Vector3 teleportPosition;
    Vector3 batteryDirection;
    [SerializeField] private float projectileSpeed = 5f;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        teleportPosition = transform.position + new Vector3(0.75f,0f,0f);
        batteryDirection = new Vector3(1f,0f,0f);
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Battery"))
        {
            other.transform.position = teleportPosition;
            other.GetComponent<Rigidbody2D>().velocity = batteryDirection * projectileSpeed;
        }
    }
}
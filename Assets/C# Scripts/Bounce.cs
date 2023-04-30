using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float expulsionForce = 10f;

    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Espacio presionado");
        //    Vector2 direction = Vector2.right;
        //    rigidBody.AddForce(direction * expulsionForce, ForceMode2D.Impulse);
        //    Debug.Log("Dirección de la fuerza: " + direction);
        //}

        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    Vector2 direction = Vector2.left;
        //    rigidBody.AddForce(direction * expulsionForce, ForceMode2D.Impulse);
        //}
    }
}

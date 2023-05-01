using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
    private BoxCollider2D managerBox;
    private Transform player;
    public GameObject boundary;

    // Start is called before the first frame update
    void Start()
    {
        managerBox = GetComponent<BoxCollider2D>();
        Debug.LogFormat("Player transform: {0}", GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>());
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //// Buscamos el boundary activo al inicio
        //foreach (GameObject boundary in boundaries)
        //{
        //    if (managerBox.bounds.Contains(boundary.transform.position))
        //    {
        //        currentBoundary = boundary;
        //        currentBoundary.SetActive(true);
        //    }
        //    else
        //    {
        //        boundary.SetActive(false);
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ManageBoundary();
    }

    void ManageBoundary()
    {
        if(managerBox.bounds.min.x < player.position.x && player.position.x < managerBox.bounds.max.x &&
        managerBox.bounds.min.y < player.position.y && player.position.y < managerBox.bounds.max.y)
        {
            boundary.SetActive(true);
        } else {
            boundary.SetActive(false);
        }
        //// Buscamos el boundary correspondiente al l�mite actual
        //foreach (GameObject boundary in boundaries)
        //{
        //    if (managerBox.bounds.Contains(boundary.transform.position))
        //    {
        //        if (boundary != currentBoundary)
        //        {
        //            // Desactivamos el boundary actual y activamos el nuevo
        //            currentBoundary.SetActive(false);
        //            currentBoundary = boundary;
        //            currentBoundary.SetActive(true);
        //        }
        //        return;
        //    }
        //}
//
        //// Si el jugador est� fuera de todos los l�mites, desactivamos el boundary actual
        //if (currentBoundary != null)
        //{
        //    currentBoundary.SetActive(false);
        //    currentBoundary = null;
        //}
    }
}
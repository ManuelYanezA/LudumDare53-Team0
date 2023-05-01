using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform laserPosition;
    public float damage = 10f;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        lineRenderer.SetPosition(0, laserPosition.position);
        lineRenderer.SetPosition(1, hit.point);

        AlphaMovement player = hit.collider.GetComponent<AlphaMovement>();
        if(player != null)
        {
            player.TakeDamage(damage);
        }
    }
}

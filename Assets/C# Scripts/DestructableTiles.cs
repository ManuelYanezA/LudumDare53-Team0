using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructableTiles : MonoBehaviour
{
    public Tilemap destructableTilemap;

    private void Start()
    {
        destructableTilemap = GetComponent<Tilemap>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Robot"))
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in other.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                Debug.Log("Tile destruido en: " + destructableTilemap.WorldToCell(hitPosition + (Vector3)(hit.normal * 0.1f)));
                destructableTilemap.SetTile(destructableTilemap.WorldToCell(hitPosition + (Vector3)(hit.normal * 0.1f)), null);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");
            foreach (GameObject robot in robots)
            {
                Vector3 robotPosition = robot.transform.position;
                Vector3Int cellPosition = destructableTilemap.WorldToCell(robotPosition);
                destructableTilemap.SetTile(cellPosition, null);
            }
        }
    }

}

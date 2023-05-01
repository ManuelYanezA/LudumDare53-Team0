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
        //Debug.LogFormat("Collision with {0}", other.gameObject.name);
        //Debug.LogFormat("Collision with {0}", other.gameObject.tag);
        if(other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Collision with Beta");
            Vector3 hitPosition = Vector3.zero;
            foreach(ContactPoint2D hit in other.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                //Debug.Log("Hit!");
                destructableTilemap.SetTile(destructableTilemap.WorldToCell(hitPosition), null);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelScript : MonoBehaviour
{
    public string scene;
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.name == "Alpha")
        {

            if (SceneManager.GetActiveScene().name == "Credits")
            {
                Destroy(BackgroundMusic.instance.gameObject);
            }
            SceneManager.LoadScene(scene);

        }
    }
}

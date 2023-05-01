using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuInicial : MonoBehaviour
{
    public AudioSource audioSource;

    public void Start()
    {
        audioSource = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
    }
    public void Play()
    {
        audioSource.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Exit() 
    {
        Debug.Log("Exit....");
        Application.Quit();
    }
}

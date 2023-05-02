using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuInicial : MonoBehaviour
{
    public AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Play()
    {

        SceneManager.LoadScene("Level 1");
        if (BackgroundMusic.instance != null)
        {
            BackgroundMusic.instance.GetComponent<AudioSource>().Stop();
            Destroy(BackgroundMusic.instance.gameObject);
        }
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

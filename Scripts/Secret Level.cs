using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SecretLevel : MonoBehaviour
{

    private GameObject music;
    private GameObject current_music;

    void Start()
    {
        music = GameObject.FindWithTag("Music");
        current_music = music.transform.GetChild(3).gameObject;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag("Player") )
        {
            current_music.GetComponent<AudioSource>().Stop();
            SceneManager.LoadScene("secret level");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SecretLevel : MonoBehaviour
{

    private GameObject music;
    private GameObject current_music;
    private GameObject[] Es;
    private Collider2D collider;

    void Start()
    {
        collider = GetComponent<Collider2D>();
        music = GameObject.FindWithTag("Music");
        current_music = music.transform.GetChild(3).gameObject;

    }

    void Update()
    {
        Es = GameObject.FindGameObjectsWithTag("Enemy");

        if (Es.Length <= 5)
            collider.enabled = true;

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

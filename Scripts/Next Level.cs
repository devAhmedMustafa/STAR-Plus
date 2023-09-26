using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    private GameObject music;
    [SerializeField]
    private GameObject current_music;
    private string scene;
    private int lvl;
    
    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
        lvl = scene[scene.Length - 1];
        music = GameObject.FindWithTag("Music");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CloseLevelDoor();
            current_music.GetComponent<AudioSource>().Stop();
            

            if (scene == "secret level")
                SceneManager.LoadScene("level4");
            else
                SceneManager.LoadScene("level" + Convert.ToChar(int.Parse(Convert.ToString(lvl))+1));
        }

        void CloseLevelDoor()
        {
            GameObject.FindWithTag("LevelDoor").GetComponent<Door>().CloseDoor();
        }

    }
}

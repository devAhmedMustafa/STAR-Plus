using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    private GameObject camera;
    private CameraFollow camera_class;
    private GameObject music;
    

    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera");
        music = GameObject.FindWithTag("Music");
        
        camera_class = camera.GetComponent<CameraFollow>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player"))
        {
            OptimizingCamera();
            CloseMainDoor();
            ChangingMusic();
        }

         void OptimizingCamera()
        {
            camera.GetComponent<Camera>().orthographicSize = 10f;
            camera_class.XMax = new Vector2(-12.04f, -1.4f);
            camera_class.YMax = new Vector2(-6.5f, 19.87f);
        }

        void ChangingMusic()
        {
            music.transform.GetChild(0).GetComponent<AudioSource>().Stop();
            music.transform.GetChild(1).GetComponent<AudioSource>().Play();
        }

        void CloseMainDoor()
        {
            GameObject.FindWithTag("Door").GetComponent<Door>().CloseDoor();
        }

    }
}

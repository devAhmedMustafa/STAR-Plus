using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windows : MonoBehaviour
{
    private GameObject camera;
    private Canvas canvas;
    void Start()
    {
        canvas = GetComponent<Canvas>();
        camera = GameObject.FindWithTag("MainCamera");
        canvas.worldCamera = camera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

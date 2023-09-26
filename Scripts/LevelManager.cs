using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameObject[] e;
    private GameObject Level_Door;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Level_Door = GameObject.FindWithTag("LevelDoor");
    }

    void Update()
    {
        e = GameObject.FindGameObjectsWithTag("Enemy");

        if(e.Length <= 0)
            Level_Door.GetComponent<Door>().OpenDoor();
    }
}

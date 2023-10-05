using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject music;

    void Start()
    {
        music.GetComponent<AudioSource>().Play();
    }

    void OnEnable()
    {
        BossPhaseManager.BossPhase += StopMusic;
    }

    void OnDisable()
    {
        BossPhaseManager.BossPhase -= StopMusic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StopMusic()
    {
        music.GetComponent<AudioSource>().Stop();
    }
}

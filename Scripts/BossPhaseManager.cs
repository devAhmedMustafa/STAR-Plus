using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseManager : MonoBehaviour
{
    
    public delegate void BossPhaseDelegate();
    public static event BossPhaseDelegate BossPhase;

    [SerializeField]
    private GameObject music, trap;
    private Boss boss;
    private bool instantiated, played;

    void Start()
    {
        boss = GameObject.FindWithTag("Boss").GetComponent<Boss>();
        instantiated = played = false;
    }

    void Phase2()
    {
        if (boss.Health == 25f)
            BossPhase?.Invoke();
    }


    void Update()
    {
        Phase2Music();
        Phase2();
        ShowTraps();
    }

    void ShowTraps()
    {
        if (boss.Health <= 25f && !instantiated)
        {
            Instantiate(trap);
            instantiated = true;
        }
    }

    void Phase2Music()
    {

        if ( boss.Health <= 25f && !played)
        {
            music.GetComponent<AudioSource>().Play();
            played = true;
        }

    }
}

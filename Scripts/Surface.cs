using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{

    private AudioSource walk_sfx;

    
    void Start()
    {
        walk_sfx = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Walk();

        void Walk()
        {
            if (collision.gameObject.GetComponent<Player>().Move > 0)
                if (!walk_sfx.isPlaying)
                    walk_sfx.Play(0);
        }
                
    }
}

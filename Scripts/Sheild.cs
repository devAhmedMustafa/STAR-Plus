using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sheild : MonoBehaviour
{

    private readonly string Sheild_Animation = "PuttingSheild";
    private bool sheilded = false;
    private GameObject Player;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        StartCoroutine( PutSheild() );
    }

    IEnumerator PutSheild()
    {
        if ( Input.GetMouseButtonDown(1) && !sheilded )
        {
            anim.SetInteger(Sheild_Animation, 1);
            yield return new WaitForSeconds(0.3f);
            anim.SetInteger(Sheild_Animation, 2);
            sheilded=true;
            
        }
        if (Input.GetMouseButtonDown(1) && sheilded)
        {
            anim.SetInteger(Sheild_Animation, 3);
            yield return new WaitForSeconds(0.3f);
            anim.SetInteger(Sheild_Animation, 4);
            sheilded = false;
        }

    }

}

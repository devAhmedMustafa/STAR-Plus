using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAttack : MonoBehaviour
{

    [SerializeField]
    private GameObject arrow;
    private bool attack;
    private AudioSource arrow_sfx;
    public bool Attack
    {
        set { attack = value; }
    }

    void Start()
    {
        arrow_sfx = GetComponent<AudioSource>();
        StartCoroutine(MakeArrow());
    }

    void Update()
    {
        if (attack)
        {
            Debug.Log("Attack");
        }
    }

    IEnumerator MakeArrow()
    {
        while( true )
        {
            if ( attack )
            {
                Instantiate(arrow);
                arrow_sfx.Play();
            }
            yield return new WaitForSeconds(Random.Range(1, 4));
        }
    }
}

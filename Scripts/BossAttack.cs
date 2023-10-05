using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weapons;
    private GameObject Player;
    private GameObject Hammer;
    private GameObject Axe;
    public bool axeAttack, hammerAttack;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Hammer = transform.GetChild(0).gameObject;
        Axe = transform.GetChild(1).gameObject;
        axeAttack = hammerAttack = false;
    }

    
    void Update()
    {
        AxeAttack();
        HammerAttack();
    }

    float CalculateDistance(Vector2 e)
    {
        float ex = e[0], ey = e[1];
        float px = Player.transform.position.x, py = Player.transform.position.y;

        return Convert.ToSingle(Math.Sqrt(Math.Pow(ex - px, 2) + Math.Pow(ey - py, 2)));
    }

    void HammerAttack()
    {
        float hx = Hammer.transform.position.x, hy = Hammer.transform.position.y;
        if (CalculateDistance(new Vector2(hx, hy)) <= 3.8f && hammerAttack){
            Hammer.GetComponent<Animator>().SetBool("Attack", true);
            weapons[0].GetComponent<Weapon>().Attacking = true;
        }
        else
        {
            Hammer.GetComponent<Animator>().SetBool("Attack", false);
            weapons[0].GetComponent<Weapon>().Attacking = false;
        }
    }

    void AxeAttack()
    {
        if ( axeAttack )
        {
            Axe.GetComponent<Animator>().SetBool("Attack", true);
            weapons[1].GetComponent<Weapon>().Attacking = true;
        }
        else
        {
            Axe.GetComponent<Animator>().SetBool("Attack", false);
            weapons[1].GetComponent<Weapon>().Attacking = false;    
        }
    }
}

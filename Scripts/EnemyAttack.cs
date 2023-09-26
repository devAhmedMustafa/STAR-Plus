using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private bool attacking;
    private Animator anim;
    private bool blocked;
    private GameObject Parent;
    [SerializeField]
    private GameObject[] Weapons;

    void Start()
    {
        Parent = transform.parent.gameObject;
        try
        {
            anim = GetComponentInParent<Animator>();
        }
        catch { }
    }
    void Update()
    {
        attacking = Parent.GetComponent<Enemy>().Attacking;
        if (anim)
            AttackAnimate();
        Attack();
    }

    void AttackAnimate()
    {
        if (attacking) {
            anim.SetBool("Attack", true);
        } 
        else
        {
            anim.SetBool("Attack", false);
        }
    }

    void Attack()
    {
        if (attacking)
        {
            for (int i = 0;  i < Weapons.Length; i++)
            {
                Weapons[i].GetComponent<Weapon>().Attacking = true;
            }
        }
        else
        {
            for (int i = 0; i < Weapons.Length; i++)
            {
                Weapons[i].GetComponent<Weapon>().Attacking = true;
            }
        }
    }
}

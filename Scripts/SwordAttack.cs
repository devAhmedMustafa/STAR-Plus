using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private bool attacking;
    private Animator anim;
    private string Attacking_Animation = "Attacking";
    private string ENEMY = "Enemy";
    private float attack_damage;

    public float AttackDamage
    {
        set { attack_damage = value; }
    }

    void Start()
    {
        attacking = false;
        attack_damage = 1f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine( Attack() );
    }
    IEnumerator Attack()
    {
        if (Input.GetMouseButtonDown(0) && !attacking)
        {
            attacking = true;
            anim.SetBool(Attacking_Animation, true);  
            yield return new WaitForSeconds(0.35f);
            anim.SetBool(Attacking_Animation, false);
            attacking = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY) && attacking)
        {
            DamageEnemy(collision, attack_damage);
        }
    }

    public static void DamageEnemy(Collider2D collision ,float damage)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        enemy.Health -= damage;
        enemy.Damaged = true;
    }
}

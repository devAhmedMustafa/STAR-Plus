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
    private AudioSource sound;
    public float AttackDamage
    {
        set { attack_damage = value; }
    }

    void Start()
    {
        attacking = false;
        attack_damage = 1f;
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
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
            sound.Play();
            yield return new WaitForSeconds(0.35f);
            anim.SetBool(Attacking_Animation, false);
            attacking = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (attacking)
        {
            if (collision.gameObject.CompareTag(ENEMY))
                DamageEnemy(collision, attack_damage);
            else if (collision.gameObject.CompareTag("Boss"))
                DamageBoss(collision, attack_damage);

        }
    }

    public static void DamageEnemy(Collider2D collision ,float damage)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        enemy.Health -= damage;
        enemy.Damaged = true;
    }

    public static void DamageBoss(Collider2D collision, float damage)
    {
        Boss boss = collision.gameObject.GetComponent<Boss>();
        boss.Health -= damage;
        boss.Damaged = true;
    }
}

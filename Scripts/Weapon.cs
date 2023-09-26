using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Weapon : MonoBehaviour
{

    private bool attacking;
    private bool blocked;

    public bool Attacking
    {
        set { attacking = value; }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("sheild"))
        {
            blocked = true;
            Debug.Log("Blocked");
        }
        else
        {
            blocked = false;
        }
        if (collision.CompareTag("Player") && attacking && !blocked)
        {
            Debug.Log("Hit");
            DamagePlayer(1f);
        }

    }

    public static void DamagePlayer(float damage)
    {
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.Health -= damage;
        player.Damaged = true;
    }

}

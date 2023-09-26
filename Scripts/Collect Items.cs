using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{

    private GameObject Player;
    private GameObject Sword;
    private GameObject HealthManager;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Sword = Player.transform.GetChild(2).gameObject;
        HealthManager = Player.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if ( collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("Collected");

            if (gameObject.name == "Attack")
                Sword.GetComponent<SwordAttack>().AttackDamage = 5f;
            else if (gameObject.name == "Health")
            {
                HealthManager.GetComponent<HealthManager>().MaxHealth = 35f;
                Player.GetComponent<Player>().Health = 35f;
            }

            Destroy(transform.parent.gameObject);
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trap : MonoBehaviour
{

    private GameObject Player;
    private Vector2 diff;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        diff = CalculateDistance();
    }

    Vector2 CalculateDistance()
    {
        float ex = transform.position.x, ey = transform.position.y;
        float px = Player.transform.position.x, py = Player.transform.position.y;

        float xDiff = px - ex, yDiff = py - ey;

        return new Vector2(xDiff, yDiff);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag("Player"))
        {
            PushPlayer(collision);
        }
    }

    void PushPlayer(Collision2D collision)
    {
        Weapon.DamagePlayer(5f);
        collision.gameObject.GetComponent<Player>().Stable = false;
        collision.rigidbody.AddForce(new Vector2 (1, 1) * diff * 10f, ForceMode2D.Impulse);
    }
}

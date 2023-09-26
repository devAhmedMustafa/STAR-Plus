using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float AreaR;
    private bool seen;
    private float speed;
    private float distance;
    private GameObject Player;
    [SerializeField]
    private float attackRange;
    private GameObject hands;
    [SerializeField]
    private GameObject _character;
    private float health;
    private bool damaged;
    private bool attacking;

    public bool Attacking
    {
        get { return attacking; }
    }
    public float Health
    {
        get { return health; }
        set { health = value; }
    }
    public bool Damaged
    {
        get { return damaged; }
        set { damaged = value; }
    }

    void Start()
    {
        hands = transform.Find("hands").gameObject;
        Player = GameObject.FindWithTag("Player");
        speed = 4f;
        health = 3f;
        AreaR = 16f;
        distance = 100f;
        seen = false;
    }

    void Update()
    {
        CalculateDistance();
        AttackPlayer();
        FollowPlayer();
        Die(); 
    }

    void FixedUpdate()
    {
        StartCoroutine(TakeDamage());
    }

    void CalculateDistance()
    {
        float ex = transform.position.x, ey = transform.position.y;
        float px = Player.transform.position.x, py = Player.transform.position.y;

        distance = Convert.ToSingle(Math.Sqrt(Math.Pow(ex - px, 2) + Math.Pow(ey - py, 2)));
    }

    void FollowPlayer()
    { 
        Vector3 player_pos = Player.transform.position;

        float ex = transform.position.x; float ey = transform.position.y;
        float px = player_pos.x; float py = player_pos.y;

        float x = 0, y = 0;

        if (distance < AreaR)
            seen = true;

        if ( seen )
        {
            if (!attacking)
            {
                if (ex > px)
                    x = -1f;
                else if (ex < px)
                    x = 1f;
                if (ey > py)
                    y = -1f;
                else if (ey < py)
                    y = 1f;
            }
            Modify_Direction(px, py, ex, ey);

            Move(x, y);
            
        }
  

        void Modify_Direction(float px, float py, float ex, float ey)
        {

            float yDiff = Math.Abs(ey - py);

            double sinTheta = yDiff / distance;
            float theta = Convert.ToSingle(Math.Asin(sinTheta) * (180f / Math.PI));

            if (ex >= px && ey >= py)
            {
                theta = 180 + theta;
            }
            else if (ex >= px)
            {
                theta = 180 - theta;
            }
            else if (ey >= py)
            {
                theta = 360 - theta;
            }

            Quaternion target = Quaternion.Euler(0, 0, theta);
            Quaternion reset = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(reset, target, 1f);
        }

        void Move(float x, float y)
        {
            transform.position += speed * Time.deltaTime * new Vector3(x, y, 0);
        }
    }

    void AttackPlayer()
    {
        if (distance <= attackRange && !damaged)
            Attack();
        else
            Idle();

        void Attack()
        {
            attacking = true;
        }

        void Idle()
        {
            attacking = false;
        }

    }

    void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator TakeDamage()
    {
        if (damaged)
        {
            _character.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.2f);
            damaged = false;
        }
        else
            _character.GetComponent<SpriteRenderer>().color = Color.white;

    }

}

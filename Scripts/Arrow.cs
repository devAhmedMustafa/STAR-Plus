using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    private bool blocked;
    private Rigidbody2D body;
    private Transform Player;
    private Vector2 v;
    private GameObject _stack;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        _stack = GameObject.FindWithTag("Arrow Stack");
        transform.position = _stack.transform.position;
        Player = GameObject.FindWithTag("Player").transform;
        Modify_Direction(Player.position.x, Player.position.y, transform.position.x, transform.position.y);
        v = CalculateDiffs();
        body.AddForce(300f * Time.deltaTime * v, ForceMode2D.Impulse);
    }

    void Update()
    {
    }

    Vector2 CalculateDiffs()
    {
        float dx, dy;

        dx = Player.position.x - transform.position.x;
        dy = Player.position.y - transform.position.y;

        return new Vector2(dx, dy);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("sheild"))
            blocked = true;
        else
                blocked = false;

        if (collision.gameObject.CompareTag("Player") && !blocked && body.velocity != Vector2.zero )
            Weapon.DamagePlayer(1f);

        body.velocity = Vector2.zero;
        body.angularVelocity = 0;
        Destroy(gameObject);
    }

    void Modify_Direction(float px, float py, float ex, float ey)
    {
        float yDiff = Math.Abs(ey - py);

        double sinTheta = yDiff / CalculateDistance();
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

        Quaternion target = Quaternion.Euler(0, 0, theta-90);
        Quaternion reset = Quaternion.Euler(0, 0, 0);
        transform.rotation = Quaternion.Slerp(reset, target, 1f);

        float CalculateDistance()
        {
            float ex = transform.position.x, ey = transform.position.y;
            float px = Player.position.x, py = Player.position.y;

            return Convert.ToSingle(Math.Sqrt(Math.Pow(ex - px, 2) + Math.Pow(ey - py, 2)));
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Knife : MonoBehaviour
{
    private GameObject _stack;
    private Rigidbody2D body;
    private Vector2 v;
    private Vector3 mousePos;

    private Vector3 dim;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        _stack = GameObject.FindWithTag("sheild");
        transform.position = _stack.transform.position;
        
        FollowMouse();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        v = CalculateDiffs();
        body.AddForce(300f * Time.deltaTime * v, ForceMode2D.Impulse);
    }

    Vector2 CalculateDiffs()
    {
        float dx, dy;

        dx = mousePos.x - transform.position.x;
        dy = mousePos.y - transform.position.y;

        return new Vector2(dx, dy);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Boss") && body.velocity != Vector2.zero)
            Damage();

        body.velocity = Vector2.zero;
        body.angularVelocity = 0;
        Destroy(gameObject);

        void Damage()
        {
            Boss boss = collision.gameObject.GetComponent<Boss>();
            boss.Health -= 2f;
            boss.Damaged = true;
            boss.Freeze();
        }
    }

    void FollowMouse()
    {
        dim = transform.position;

        float dimx = dim.x; float mx = mousePos.x;
        float dimy = dim.y; float my = mousePos.y;

        float diag = Convert.ToSingle(Math.Sqrt(Math.Pow(dimx - mx, 2) + Math.Pow(dimy - my, 2)));

        float yDiff = Math.Abs(my - dimy);

        double tanTheta = yDiff / diag;
        float theta = Convert.ToSingle(Math.Asin(tanTheta) * (180f / Math.PI));

        if (dimx >= mousePos.x && dimy >= mousePos.y)
        {
            theta = 180 + theta;
        }
        else if (dimx >= mousePos.x)
        {
            theta = 180 - theta;
        }
        else if (dimy >= mousePos.y)
        {
            theta = 360 - theta;
        }

        Quaternion target = Quaternion.Euler(0, 0, theta);
        Quaternion reset = Quaternion.Euler(0, 0, 0);
        transform.rotation = Quaternion.Slerp(reset, target, 1f);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class Player : MonoBehaviour
{

    public delegate void PlayerDied();
    public static event PlayerDied PlayerDiedInfo; 

    private float speed = 10f;
    private float moveX, moveY;
    private Vector3 dim;
    private float health;
    private GameObject _character;
    private bool damaged;
    private AudioSource damageSFX;
    private Rigidbody2D rb;
    private bool stable;

    public bool Stable
    {
        set { stable = value; }
    }

    public float Move
    {
        get { return Convert.ToSingle(Math.Sqrt(Math.Pow(moveX,2) + Math.Pow(moveY,2)));}
    }

    public bool Damaged
    {
        get { return damaged; }
        set { damaged = value; }
    }

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 10f;
        _character = transform.Find("green_character").gameObject;
        damageSFX = GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();
        FollowMouse();
        StartCoroutine(TakeDamageEffect());
        Die();
    }

    void LateUpdate()
    {
        StartCoroutine(Stability());
    }

    IEnumerator Stability()
    {
        if (stable)
        {
            rb.velocity = Vector2.zero; 
            rb.angularVelocity = 0;
        }
        else {
            yield return new WaitForSeconds(0.4f);
            stable = true;
        }
        
    }

    void Movement()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        
        transform.position += new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
    }

    void FollowMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
        Quaternion reset = Quaternion.Euler(0, 0,0);
        transform.rotation = Quaternion.Slerp(reset, target, 1f);
    }

    IEnumerator TakeDamageEffect()
    {
        if (damaged)
        {
            _character.GetComponent<SpriteRenderer>().color = Color.red;
            damageSFX.Play();
            yield return new WaitForSeconds(0.2f);
            damaged = false;
        }
        else
            _character.GetComponent<SpriteRenderer>().color = Color.white;

    }

    void Die()
    {
        if ( health <= 0)
        {
            Destroy(gameObject);
            PlayerDiedInfo?.Invoke();
        }
    }
}

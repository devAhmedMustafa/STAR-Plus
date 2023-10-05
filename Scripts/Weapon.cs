using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Weapon : MonoBehaviour
{

    private bool attacking;
    private bool blocked;
    private AudioSource sfx;

    [SerializeField]
    private float damage;

    public bool Attacking
    {
        set { attacking = value; }
    }

    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    void Update()
    {
       StartCoroutine( Sound());
    }

    Vector2 CalculateDistance(Transform p)
    {
        float ex = transform.position.x, ey = transform.position.y;
        float px = p.position.x, py = p.position.y;

        float xDiff = px - ex, yDiff = py - ey;

        return new Vector2(xDiff, yDiff);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("sheild"))
        {
            blocked = true;
        }
        else
        {
            blocked = false;
        }
        if (collision.gameObject.CompareTag("Player") && attacking && !blocked)
        {
            DamagePlayer(damage);
            PushPlayer(collision, 0.2f * damage * CalculateDistance(collision.transform));
        }

    }

    public static void DamagePlayer(float damage)
    {
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.Health -= damage;
        player.Damaged = true;
    }

    void PushPlayer(Collision2D collision, Vector2 diff)
    {
        collision.gameObject.GetComponent<Player>().Stable = false;
        collision.rigidbody.AddForce(new Vector2(1, 1) * diff * 10f, ForceMode2D.Impulse);
    }

    IEnumerator Sound()
    {
        if (attacking && !sfx.isPlaying)
        {
            sfx.Play(0);
            yield return new WaitForSeconds(0.3f);
        }
        else
        {
            sfx.Stop();
        }
    }

}

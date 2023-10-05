using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Boss : MonoBehaviour
{

    private float distance;
    private GameObject Player;
    private float health;
    private bool damaged;
    private GameObject hands;
    private Rigidbody2D rb;
    private bool attacking;
    [SerializeField]
    private GameObject ArrowStack;
    [SerializeField]
    private GameObject _character;
    private bool freezed;
    public Color default_color;

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public bool Damaged
    {
        set { damaged = value; }
    }

    public delegate void BossDiedDelegate();
    public static event BossDiedDelegate BossDied;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player");
        hands = transform.Find("hands").gameObject;
        health = 50;
        freezed = false;
        default_color = Color.white;
    }

    void OnEnable()
    {
        BossPhaseManager.BossPhase += Phase2Color;
    }

    void OnDisable()
    {
        BossPhaseManager.BossPhase -= Phase2Color;
    }


    void Update()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        CalculateDistance();
        if (!attacking && !freezed)
            Modify_Direction();

        AttackWithAxe();
        ArrowAttack();
        HammerAttack();
        FreezeEffect();
        Die();
    }

    

    void LateUpdate()
    {
        StartCoroutine(TakeDamage());
    }

    void CalculateDistance()
    {
        float ex = transform.position.x, ey = transform.position.y;
        float px = Player.transform.position.x, py = Player.transform.position.y;

        distance = Convert.ToSingle(Math.Sqrt(Math.Pow(ex - px, 2) + Math.Pow(ey - py, 2)));
    }

    void Modify_Direction()
    {
        float ex = transform.position.x, ey = transform.position.y;
        float px = Player.transform.position.x, py = Player.transform.position.y;

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

    void AttackWithAxe()
    {
        if (distance <= 18f && !freezed)
        {
            hands.GetComponent<BossAttack>().axeAttack = true;
            attacking = true;
        }
        else
        {
            hands.GetComponent<BossAttack>().axeAttack = false;
            attacking = false;
        }
    }

    void ArrowAttack()
    {
        if (distance >= 15f && !freezed)
        {
            ArrowStack.GetComponent<ArrowAttack>().Attack = true;
        }
        else
            ArrowStack.GetComponent<ArrowAttack>().Attack = false;
    }

    void HammerAttack()
    {
        if (distance <= 20f && !freezed)
        {
            hands.GetComponent<BossAttack>().hammerAttack = true;
        }
        else
            hands.GetComponent<BossAttack>().hammerAttack = false;
    }

    void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            BossDied?.Invoke();
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
            if (!freezed)
                _character.GetComponent<SpriteRenderer>().color = default_color;

    }

    public void Freeze()
    {
        StartCoroutine(Freezing());
    }

    void FreezeEffect()
    {
        if (freezed)
            _character.GetComponent<SpriteRenderer>().color = new Color(202, 114, 255);
        else
            _character.GetComponent<SpriteRenderer>().color = default_color;
    }

    IEnumerator Freezing()
    {
        freezed = true;
        
        yield return new WaitForSeconds(5f);
        freezed = false;
        
    }

    void Phase2Color()
    {
        default_color = Color.black;
    }

}

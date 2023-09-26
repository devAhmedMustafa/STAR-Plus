using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private Image healthbar;
    [SerializeField]
    private Text healthnum;
    private float health;
    private float max_heal;

    public float MaxHealth
    {
        set { health = value; }
    }

    void Start()
    {
        max_heal = 25f;
    }

    
    void Update()
    {
        health = GameObject.FindWithTag("Player").GetComponent<Player>().Health;
        healthbar.fillAmount = health / max_heal;
        healthnum.text = health.ToString();
    }
}

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
    [SerializeField]
    private float max_heal;
    [SerializeField]
    private GameObject character;

    public float MaxHealth
    {
        set { health = value; }
    }

    void Start()
    {
    }

    
    void Update()
    {
        if (character.name == "Player")
            health = character.GetComponent<Player>().Health;
        else if (character.name == "Boss")
            health = character.GetComponent<Boss>().Health;
        healthbar.fillAmount = health / max_heal;
        healthnum.text = health.ToString();
    }
}

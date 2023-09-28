using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] UIs;

    void Awake()
    {
        
    }

    void OnEnable()
    {
        Player.PlayerDiedInfo += RestartScreenListener;
    }

    void OnDisable()
    {
        Player.PlayerDiedInfo -= RestartScreenListener;
    }

    void Update()
    {
        
    }

    void RestartScreenListener()
    {
        Instantiate(UIs[0]);
    }
}

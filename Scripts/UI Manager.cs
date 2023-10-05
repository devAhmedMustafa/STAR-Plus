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
        Boss.BossDied += WinScreenListener;
    }

    void OnDisable()
    {
        Player.PlayerDiedInfo -= RestartScreenListener;
        Boss.BossDied -= WinScreenListener;
    }

    void Update()
    {
        
    }

    void RestartScreenListener()
    {
        Instantiate(UIs[0]);
    }

    void WinScreenListener()
    {
        Instantiate(UIs[1]);
    }
}

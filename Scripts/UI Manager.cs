using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] UIs;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
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

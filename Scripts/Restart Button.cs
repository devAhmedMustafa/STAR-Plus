using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RestartGame()
    {
        Debug.Log("Restarted");
        SceneManager.LoadScene("Level1");
    }
}

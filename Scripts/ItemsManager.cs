using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    private GameObject[] e;
    [SerializeField]
    private GameObject items;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        e = GameObject.FindGameObjectsWithTag("Enemy");

        if (e.Length <= 0)
            Instantiate(items);
            
    }
}

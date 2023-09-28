using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    private GameObject[] e;
    [SerializeField]
    private GameObject items;
    private bool instantiated;
    void Start()
    {
        instantiated = false;
    }

    // Update is called once per frame
    void Update()
    {
        e = GameObject.FindGameObjectsWithTag("Enemy");

        if (e.Length <= 0 && !instantiated){
            Instantiate(items);
            instantiated = true;
        }
            
    }
}

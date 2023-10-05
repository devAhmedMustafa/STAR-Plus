using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifesAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject knife;
    private float load;

    void Start()
    {
        load = 7f;
    }

    
    void Update()
    {
        MakeKnife();
    }

    void MakeKnife()
    {
        if (Input.GetMouseButtonDown(1) && load > 0)
        {
            Instantiate(knife);
            load--;
        }
    }
}

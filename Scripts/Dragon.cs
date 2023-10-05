using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{

    private float speed;
    
    void Start()
    {
        speed = 10f;
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        transform.position += speed * Time.deltaTime * new Vector3(1f, 0, 0);
    }
}

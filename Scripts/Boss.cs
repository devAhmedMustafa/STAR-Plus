using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private float distance;
    private GameObject Player;
    
    
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    
    void Update()
    {
        CalculateDistance();
        Modify_Direction();
    }

    void CalculateDistance()
    {
        float ex = transform.position.x, ey = transform.position.y;
        float px = Player.transform.position.x, py = Player.transform.position.y;

        distance = Convert.ToSingle(Math.Sqrt(Math.Pow(ex - px, 2) + Math.Pow(ey - py, 2)));
    }

    void Modify_Direction()
    {
        float ex = transform.position.x, ey = transform.position.y;
        float px = Player.transform.position.x, py = Player.transform.position.y;

        float yDiff = Math.Abs(ey - py);

        double sinTheta = yDiff / distance;
        float theta = Convert.ToSingle(Math.Asin(sinTheta) * (180f / Math.PI));

        if (ex >= px && ey >= py)
        {
            theta = 180 + theta;
        }
        else if (ex >= px)
        {
            theta = 180 - theta;
        }
        else if (ey >= py)
        {
            theta = 360 - theta;
        }

        Quaternion target = Quaternion.Euler(0, 0, theta);
        Quaternion reset = Quaternion.Euler(0, 0, 0);
        transform.rotation = Quaternion.Slerp(reset, target, 1f);
    }
}

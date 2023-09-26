using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;
    private Vector3 pos;
    [SerializeField]
    private Vector2 max_X, max_Y;

    public Vector2 XMax
    {
        get { return max_X; }
        set { max_X = value; }
    }

    public Vector2 YMax
    {
        get { return max_Y; }
        set { max_Y = value; }
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {

        pos = transform.position;

        try
        {
            pos.x = player.position.x;
            pos.y = player.position.y;
        }
        catch
        {
        }
        
        if ( pos.x < max_X[0] )
            pos.x = max_X[0];
        else if ( pos.x > max_X[1] )
            pos.x = max_X[1];
        
        if ( pos.y < max_Y[0] )
            pos.y = max_Y[0];
        else if ( pos.y > max_Y[1] )
            pos.y = max_Y[1];

        transform.position = pos;
    }
}

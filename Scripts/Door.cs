using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool open;
    private Collider2D collider;
    private Animator anim;
    private readonly string DOOR_ANIMATION = "Open";


    void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }


    void Update()
    {
        SetCollider();
        SetDoorSprite();
    }

    void SetCollider()
    {
        if ( open )
        {
            collider.enabled = false;
        }
        else
        {
            collider.enabled = true;
        }
    }
    void SetDoorSprite()
    {
        if ( open )
            anim.SetBool(DOOR_ANIMATION, true);
        else
            anim.SetBool(DOOR_ANIMATION, false);
    }

    public void CloseDoor()
    {
        open = false;
    }

    public void OpenDoor()
    {
        open = true;
    }
}

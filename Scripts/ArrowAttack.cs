using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAttack : MonoBehaviour
{

    [SerializeField]
    private GameObject arrow;
    private GameObject parent;
    private bool attack;

    void Start()
    {
        parent = transform.parent.gameObject.transform.parent.gameObject;
        StartCoroutine(MakeArrow());
    }

    void Update()
    {
        attack = parent.GetComponent<Enemy>().Attacking;
    }

    IEnumerator MakeArrow()
    {
        while( true )
        {
            if ( attack )
            {
                Instantiate(arrow);
            }
            yield return new WaitForSeconds(Random.Range(1, 4));
        }
    }
}

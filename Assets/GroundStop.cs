using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundStop : MonoBehaviour
{
    [SerializeField] Transform root;
    [SerializeField] LayerMask ground;
    [SerializeField] bool isMove;

    void OnEnable()
    {
        isMove = true;
    }

    void Update()
    {
        if (isMove)
        {
            transform.position = root.position;
            transform.rotation = root.rotation;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(1 << collision.gameObject.layer == ground)
        {
            isMove = false;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if(1 << collision.gameObject.layer == ground)
        {
            isMove = true;
        }
    }
}

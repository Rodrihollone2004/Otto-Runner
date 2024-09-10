using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMov : MonoBehaviour
{
    public float scrollFactor = -1;
    public Vector3 gameVelocity;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = gameVelocity * scrollFactor;
    }

    private void OnTriggerExit(Collider gameArea)
    {
        transform.position += Vector3.right * (gameArea.bounds.size.x + GetComponent<BoxCollider>().size.x);
    }
    private void Update()
    {
        if (GameManger.instance.Dead)
        {
            rb.velocity = gameVelocity * 0;
        }
    }
}

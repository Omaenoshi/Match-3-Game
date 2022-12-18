using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public GameObject targetDestination;

    GameObject targetGameObject;
    private float speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = (targetDestination.transform.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Debug.Log("Contact");
        }
    }

}

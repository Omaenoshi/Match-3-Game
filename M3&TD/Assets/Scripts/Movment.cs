using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField]
    public Transform targetDestination;

    GameObject targetGameObject;
    [SerializeField]
    private float speed;

    Rigidbody2D rgbd2d;
    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        targetGameObject = targetDestination.gameObject;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
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

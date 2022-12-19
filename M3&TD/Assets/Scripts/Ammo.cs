using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 2;
    public Enemy target;

    void Start()
    {
        Tower tower = this.gameObject.GetComponentInParent<Tower>();
        target = tower.GetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        Vector3 duration = target.gameObject.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, duration, Speed);
    }
}

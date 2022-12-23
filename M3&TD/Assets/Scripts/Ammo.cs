using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    public float Speed { get; set; } = 0.2f;

    [SerializeField]
    public Enemy target { get; set; }

    private int damage { get; set; }

    void Start()
    {
        Tower tower = this.gameObject.GetComponentInParent<Tower>();
        target = tower.GetTarget();
        damage = tower.GetDamage();
    }

    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        Vector3 duration = target.gameObject.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, duration, Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.HealthMinus(damage);
        }
        Destroy(this.gameObject);
    }
}

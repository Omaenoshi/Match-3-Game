using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;

    public Transform[] players;

    private int currentIndex = 0;

    public float speed;

    public void FixedUpdate()
    {
        var duration = players[currentIndex].localPosition;

        transform.localPosition = Vector2.MoveTowards(transform.localPosition, duration, speed);
    }

    public void HealthMinus(int damage)
    {
        Health = Health - damage;
        if(Health < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Point"))
        {
            if (currentIndex < players.Length)
            {
                currentIndex++;
            }
        }
    }
}

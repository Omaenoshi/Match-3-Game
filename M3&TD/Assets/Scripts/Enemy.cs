using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] players;
    private int currentIndex = 0;

    public float speed;

    public void FixedUpdate()
    {
        var duration = players[currentIndex].localPosition;

        transform.localPosition = Vector2.MoveTowards(transform.localPosition, duration, speed);
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

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
    private Animator anim;
    private bool isDead = false;

    public float speed;
    public GameObject spawner;

    private int _id;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void setId(int id)
    {
        _id = id;
    }

    public int getId()
    {
        return _id;
    }

    public bool GetIsDead()
    {
        return isDead;
    }

    public void FixedUpdate()
    {
        if (!isDead)
        {
            var duration = players[currentIndex].localPosition;

            transform.localPosition = Vector2.MoveTowards(transform.localPosition, duration, speed);
        }
    }

    public void HealthMinus(int damage, Tower tower)
    {
        Health -= damage;
        anim.Play("Taking Damage Enemy");
        if(Health < 0)
        {
            anim.SetTrigger("IsDead");
            isDead = true;
            tower.KillEnemy(this);
            Destroy(gameObject, 1f);
        }
    }

    public void HealthMinus(int damage)
    {
        Health -= damage;
        anim.Play("Taking Damage Enemy");
        if (Health < 0)
        {
            anim.SetTrigger("IsDead");
            isDead = true;
            Destroy(gameObject, 1f);
        }
    }  
  

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Point"))
        {
            if (currentIndex < players.Length)
            {
                currentIndex++;
            }
        }
    }
}

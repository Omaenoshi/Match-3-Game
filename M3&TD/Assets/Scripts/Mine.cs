using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField]
    public int damage;
    [SerializeField]
    public int timer;

    private bool isTriggerd = false;
    private List<Enemy> enemyList = new List<Enemy>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.tag.Equals("Enemy") && !enemyList.Contains(enemy))
        {
            if(!isTriggerd)
            {
                isTriggerd = true;
                Invoke("MineTriggered", timer);
                
            }
            enemyList.Add(enemy);
        }
    }

    private void MineTriggered()
    {
        foreach(Enemy enemy in enemyList)
        {
            enemy.HealthMinus(damage);
        }
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.tag.Equals("Enemy") && enemyList.Contains(enemy))
        {
            enemyList.Remove(enemy);
        }
    }
}

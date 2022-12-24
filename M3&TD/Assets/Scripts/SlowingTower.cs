using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingTower : MonoBehaviour
{

    [SerializeField]
    public int PercentSlowing;

    [SerializeField]
    public GameObject SlowingField;

    private List<Enemy> enemyList = new List<Enemy>();
    private Dictionary<Enemy, float> enemySpeed = new Dictionary<Enemy, float>();
    void Start()
    {
        GameObject ammo = Instantiate(SlowingField, this.transform.position, Quaternion.identity);
        ammo.transform.SetParent(this.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.tag.Equals("Enemy") && !enemyList.Contains(enemy))
        {
            enemyList.Add(enemy);
            enemySpeed.Add(enemy, enemy.speed);
            enemy.speed = (enemy.speed / 100) * (100 - PercentSlowing);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.tag.Equals("Enemy") && enemyList.Contains(enemy))
        {
            enemyList.Remove(enemy);
            enemySpeed.TryGetValue(enemy, out enemy.speed);
            enemySpeed.Remove(enemy);
        }
    }
}
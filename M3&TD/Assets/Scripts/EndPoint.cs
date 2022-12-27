using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField]
    public int MaxEnemy;
    [SerializeField]
    public GameObject DefeatPanel;

    public int counter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.tag.Equals("Enemy"))
        {
            if(counter < MaxEnemy)
            {
                counter++;
                Destroy(enemy.gameObject);
            }
            else
            {
                DefeatPanel.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}

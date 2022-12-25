using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField]
    public int timeFromAttach;

    [SerializeField]
    public int Damage;

    [SerializeField]
    public GameObject Ammo;

    [SerializeField]
    public float ShoutingInterval;

    private Enemy target;
    // Start is called before the first frame update
    private List<Enemy> enemyList = new List<Enemy>();
    void Start()
    {
        InvokeRepeating("SpawnAmmo", 1, ShoutingInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null && enemyList != null && enemyList.Count > 0)
        {
            target = enemyList[enemyList.Count - 1];
        }
    }

    private void SpawnAmmo()
    {
        if (target != null)
        {
            GameObject ammo = Instantiate(Ammo, this.transform.position, Quaternion.identity);
            ammo.transform.SetParent(this.transform);
        }
        else
        {
            Debug.Log("Target is null");
        }
    }

    public Enemy GetTarget()
    {
        return target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy") && !enemyList.Contains(collision.GetComponent<Enemy>()))
        {
            //Debug.Log(count);
            enemyList.Add(collision.GetComponent<Enemy>());

        }
    }

    public int GetDamage()
    {
        return Damage;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy") && enemyList.Contains(collision.GetComponent<Enemy>()))
        {
            //Debug.Log(count);
            enemyList.Remove(collision.GetComponent<Enemy>());
        }
    }

    public void KillEnemy()
    {
        target = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject inObj;
    
    [SerializeField]
    private int WaveSize;
    [SerializeField]
    private GameObject EnemyPrefab;
    [SerializeField]
    private float EnemyInterval;
    [SerializeField]
    private Transform SpawnPoint;
    [SerializeField]
    private float StartTime;
    [SerializeField]
    private GameObject Panel;
    [SerializeField]
    private int _currentLevel;

    private int _count;

    private List<Enemy> enemies = new List<Enemy>();

    void Start()
    {
        InvokeRepeating("SpawnEnemy", StartTime, EnemyInterval);
    }

    public int GetWave()
    {
        return WaveSize;
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(EnemyPrefab, SpawnPoint.position, Quaternion.identity);
        enemy.transform.SetParent(inObj.transform);
        enemies.Add(enemy.GetComponent<Enemy>());
        _count++;
    }

    void Update()
    {
        if (_count == WaveSize - 1)
        {
            CancelInvoke();
            bool alldead = true;
            foreach(Enemy enemy in enemies)
            {
                if (enemy.GetIsDead())
                { }
                else
                {
                    alldead = false;
                }
            }
            if (alldead)
            {
                PlayerPrefs.SetInt("Level" + _currentLevel, _currentLevel);
                Panel.SetActive(true);
            }
        }
    }
}

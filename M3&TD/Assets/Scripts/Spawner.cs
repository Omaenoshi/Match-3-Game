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

    private int _count;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", StartTime, EnemyInterval);
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(EnemyPrefab, SpawnPoint.position, Quaternion.identity);
        enemy.transform.SetParent(inObj.transform);
        _count = _count + 1;
    }

    void Update()
    {
        if (_count == WaveSize)
        {
            CancelInvoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightningTower : MonoBehaviour
{
    [SerializeField]
    private int PercentBuff;

    List<Tower> m_TowerList;
    List<Mine> mines;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Tower tower = collision.GetComponent<Tower>();
        Mine mine = collision.GetComponent<Mine>();
        if (collision.CompareTag("AttackTower") && tower !=null && m_TowerList.Contains(tower))
        {
            tower.Damage = (tower.Damage / 100) * (100 + PercentBuff);
            m_TowerList.Add(tower);
        }
        if (collision.CompareTag("Mine") && mine != null && mines.Contains(mine))
        {
            mine.damage = (mine.damage / 100) * (100 + PercentBuff);
            mines.Add(mine);
        }
    }
}

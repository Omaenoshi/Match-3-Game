using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TowerManager : MonoBehaviour
{
    public static GameObject selectedBtn;

    public void SelectTower(GameObject towerBtn)
    {
        if (selectedBtn == null)
        {
            selectedBtn = towerBtn;
        }
    }

    public void SelectedTowerSpawn(GameObject spawn)
    {
        if (selectedBtn != null)
        {
            var position = spawn.transform.position;
            GameObject tower = null;
            
            
            if (selectedBtn.tag.Equals("AttackTower"))
            {
                tower = Instantiate(selectedBtn, new Vector3(position.x, position.y + 0.3f, 0f), Quaternion.identity);
            }
            else 
            {
                tower = Instantiate(selectedBtn, new Vector3(position.x, position.y + 0.5f, 0f), Quaternion.identity);
            }
            
            tower.transform.SetParent(spawn.transform);
            var localPosition = tower.transform.localPosition;
            localPosition =
                new Vector3(localPosition.x, localPosition.y, 0f);
            tower.transform.localPosition = localPosition;
            
            selectedBtn = null;
        }
    }
    
    public void SelectedTowerSpawnOnRoad(GameObject spawn)
    {
        if (selectedBtn != null && selectedBtn.tag.Equals("Mine"))
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject tower = Instantiate(selectedBtn, mousePoint, Quaternion.identity);
            tower.transform.SetParent(spawn.transform);
            var localPosition = tower.transform.localPosition;
            localPosition =
                new Vector3(localPosition.x, localPosition.y, 0f);
            tower.transform.localPosition = localPosition;

            selectedBtn = null;
        }
    }
}

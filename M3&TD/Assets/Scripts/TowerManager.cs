using UnityEngine;

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
        if (selectedBtn != null && !selectedBtn.tag.Equals("Mine") && spawn.transform.childCount == 0)
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
        if (selectedBtn != null && selectedBtn.tag.Equals("Mine") && spawn.transform.childCount == 0)
        {
            Vector3 position = spawn.transform.position;
            GameObject tower = Instantiate(selectedBtn, position, Quaternion.identity);
            tower.transform.SetParent(spawn.transform);
            var localPosition = tower.transform.localPosition;
            localPosition =
                new Vector3(localPosition.x, localPosition.y, 0f);
            tower.transform.localPosition = localPosition;

            selectedBtn = null;
        }
    }
}

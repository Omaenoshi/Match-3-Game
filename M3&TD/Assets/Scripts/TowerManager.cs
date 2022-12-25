using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private GameObject _selectedBtn;

    public void SelectTower(GameObject towerBtn)
    {
        _selectedBtn = towerBtn;
        Debug.Log(towerBtn);
    }

    public void SelectedTowerSpawn(GameObject spawn)
    {
        var position = spawn.transform.position;
        GameObject tower = Instantiate(_selectedBtn, new Vector3(position.x, position.y + 0.3f, 0f), Quaternion.identity);
        tower.transform.SetParent(spawn.transform);
        var localPosition = tower.transform.localPosition;
        localPosition =
            new Vector3(localPosition.x, localPosition.y, 0f);
        tower.transform.localPosition = localPosition;
    }
}

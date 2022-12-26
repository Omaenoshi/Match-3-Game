using System;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{
    public static GameObject selectedBtn;

    [SerializeField] private GameObject[] btns;

    private static bool _canBuy;

    [SerializeField] private ProgressBar _progressBar;

    private void Start()
    {
        _canBuy = false;

        ButtonsSetEnabled(false);
    }

    public void LetBuy()
    {
        _canBuy = true;
        
        ButtonsSetEnabled(true);
    }

    public void SelectTower(GameObject towerBtn)
    {
        if (selectedBtn == null && _canBuy)
        {
            selectedBtn = towerBtn;
        }
    }

    public void SelectedTowerSpawn(GameObject spawn)
    {
        if (selectedBtn != null && !selectedBtn.tag.Equals("Mine") && spawn.transform.childCount == 0 && _canBuy)
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

            _canBuy = false;
            _progressBar.ResetFilling();
            ButtonsSetEnabled(false);
        }
    }
    
    public void SelectedTowerSpawnOnRoad(GameObject spawn)
    {
        if (selectedBtn != null && selectedBtn.tag.Equals("Mine") && spawn.transform.childCount == 0 && _canBuy)
        {
            Vector3 position = spawn.transform.position;
            GameObject tower = Instantiate(selectedBtn, position, Quaternion.identity);
            tower.transform.SetParent(spawn.transform);
            var localPosition = tower.transform.localPosition;
            localPosition =
                new Vector3(localPosition.x, localPosition.y, 0f);
            tower.transform.localPosition = localPosition;

            selectedBtn = null;
            _canBuy = false;
            
            _progressBar.ResetFilling();
            ButtonsSetEnabled(false);
        }
    }

    private void ButtonsSetEnabled(bool isEnabled)
    {
        foreach (var t in btns)
        {
            t.GetComponent<Button>().enabled = isEnabled;
        }
    }
}

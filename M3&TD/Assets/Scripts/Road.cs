using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameObject selectedBtn = TowerManager.selectedBtn;
        if (selectedBtn != null && selectedBtn.tag.Equals("Mine"))
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject tower = Instantiate(selectedBtn, mousePoint, Quaternion.identity);
            tower.transform.SetParent(transform);
            var localPosition = tower.transform.localPosition;
            localPosition =
                new Vector3(localPosition.x, localPosition.y, 0f);
            tower.transform.localPosition = localPosition;

            TowerManager.selectedBtn = null;
        }
    }
}

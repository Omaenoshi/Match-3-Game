using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private static float _currentFillingRate;

    [SerializeField] private TowerManager _towerManager;

    private void Start()
    {
        _currentFillingRate = 0f;
        GetComponent<Image>().fillAmount = _currentFillingRate;
    }

    public void Fill(float count)
    {
        _currentFillingRate += count;
        if (_currentFillingRate >= 1f)
        {
            _towerManager.LetBuy();
            _currentFillingRate = 1f;
        }
        GetComponent<Image>().fillAmount = _currentFillingRate;
    }

    public void ResetFilling()
    {
        _currentFillingRate = 0f;
        GetComponent<Image>().fillAmount = _currentFillingRate;
    }
}

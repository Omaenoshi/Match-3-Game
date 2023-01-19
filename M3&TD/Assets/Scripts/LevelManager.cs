using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private int _currentLevel;
    [SerializeField] private GameObject[] levels;
    void Save()
    {
        
    }

    void Start()
    {
        _currentLevel = !PlayerPrefs.HasKey("Level") ? 0 : PlayerPrefs.GetInt("Level");
        
        for (var i = 0; i <= _currentLevel; i++)
        {
            if (i == levels.Length) continue;
            levels[i].GetComponent<Button>().enabled = true;
        }
    }
}

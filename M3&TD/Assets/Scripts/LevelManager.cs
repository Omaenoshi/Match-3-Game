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
        if (PlayerPrefs.HasKey("Level"))
        {
            _currentLevel = 0;
        }
        else
        {
            _currentLevel = PlayerPrefs.GetInt("Level");
            for (var i = 0; i < _currentLevel; i++)
            {
                levels[i].GetComponent<Button>().enabled = false;
            }
        }
    }
}

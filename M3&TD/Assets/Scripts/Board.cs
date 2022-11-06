using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject board;

    public GameObject crystal;
    
    public List<Sprite> sprites;

    private GameObject[,] crystals = new GameObject[7, 7];
    // Start is called before the first frame update
    void Start()
    {
        // var num = Random.Range(0, 5);
        // crystal.GetComponent<Image>().sprite = sprites[num];
        // Instantiate(crystal, board.transform);
        
        for (var i = 0; i < crystals.GetLength(0); i++)
        {
            for (var j = 0; j < crystals.GetLength(1); j++)
            {
                int num = Random.Range(0, 5);
                crystals[i, j] = crystal;
                crystals[i, j].GetComponent<Image>().sprite = sprites[num];
                Instantiate(crystals[i, j], board.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

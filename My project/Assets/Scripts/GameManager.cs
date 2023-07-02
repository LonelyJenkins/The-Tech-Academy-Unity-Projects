using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject WinMenuUI;

    public bool hasWon = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasWon)
        {
            WinMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}

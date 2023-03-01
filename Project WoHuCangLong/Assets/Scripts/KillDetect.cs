using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillDetect : MonoBehaviour
{
    private bool isInGame = true;

    public TextMeshProUGUI endingText;
    // Start is called before the first frame update
    void Start()
    {
        isInGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (isInGame)
        {
            if(col.gameObject.CompareTag("Player 1 Body"))
            {
                endingText.text = "Player 2 Wins";
                isInGame = false;
            }
        
            if(col.gameObject.CompareTag("Player 2 Body"))
            {
                endingText.text = "Player 1 Wins";
                isInGame = false;
            }
        }
    }
}

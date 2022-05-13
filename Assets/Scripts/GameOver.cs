using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text= "Your Score: " + FindObjectOfType<ScoreKeeper>().GetScore();
        int n = FindObjectOfType<ScoreKeeper>().GetScore() * -1;
        FindObjectOfType<ScoreKeeper>().UpdateScore(n);
    }

    
}

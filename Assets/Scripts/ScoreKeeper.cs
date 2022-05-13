using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score=0;

    private void Awake()
    {
        int count = FindObjectsOfType(GetType()).Length;
        if(count>1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }
    public int GetScore()
    {
        return score;
    }
    
    public void UpdateScore(int x)
    {
        score += x;
    }

}

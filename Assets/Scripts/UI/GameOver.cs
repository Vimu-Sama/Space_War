using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    private ScoreKeeper scoreKeeper;
    void Start()
    {
        scoreKeeper = ScoreKeeper.Instance;
        GetComponent<TextMeshProUGUI>().text = "Your Score: " + scoreKeeper.GetScore();
        int n = scoreKeeper.GetScore() * -1;
        scoreKeeper.UpdateScore(n);
    }


}

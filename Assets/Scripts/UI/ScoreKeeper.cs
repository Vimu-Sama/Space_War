using UnityEngine;

public class ScoreKeeper : GenericSingleton<ScoreKeeper>
{
    int score = 0;
    protected override void Awake()
    {
        base.Awake();
        if (ScoreKeeper.Instance)
            DontDestroyOnLoad(ScoreKeeper.Instance);
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

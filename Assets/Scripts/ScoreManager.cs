using UnityEngine;

public static class ScoreManager
{
    private static int score = 0;

    public static void AddScore(int value)
    {
        score += value;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void ResetScore()
    {
        score = 0;
    }
}
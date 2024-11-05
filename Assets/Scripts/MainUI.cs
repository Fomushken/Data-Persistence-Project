using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Text ScoreText;
    public GameObject GameOverText;
    public Text BestScoreText;

    public void UpdateBestScore(int score, string playerName)
    {
        BestScoreText.text = $"Best score: {playerName} : {score}";
    }

    public void UpdateScore(int points, string playerName)
    {
        ScoreText.text = $"Score: {playerName} : {points}";
    }
}

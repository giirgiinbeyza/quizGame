using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int _currentScore;

    void Start()
    {
        _currentScore = 0;
        scoreText.text = _currentScore.ToString();
    }

    public void AddScore()
    {
        _currentScore += 10;
        scoreText.text = _currentScore.ToString();
    }

    public void DeductScore()
    {
        _currentScore = _currentScore > 0 ? _currentScore - 10 : 0;
        scoreText.text = _currentScore.ToString();
    }
}
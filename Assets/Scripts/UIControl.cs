using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Text scoreText;

    private int score = 0;

    public void incrementScore(int i)
    {
        if(i > 0)
            score += i;
        scoreText.text = score.ToString();
    }

    public void resetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
}
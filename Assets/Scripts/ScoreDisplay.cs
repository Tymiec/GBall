using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public int currentScore = 0;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        currentScore = Score.Singleton.score;
        scoreText.text = "Score: " + currentScore;
    }
}

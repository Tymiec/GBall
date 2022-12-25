using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreText;
    public int score = 0;

    public static Score Singleton;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        Singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore()
    {
        score += 1;
    }
}

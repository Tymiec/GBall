using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public static Score Singleton;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Singleton = this;
    }

    public void AddScore()
    {
        score += 1;
    }
}

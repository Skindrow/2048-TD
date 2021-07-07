using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private static Text scoreText;
    [SerializeField] private static int score;

    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }


    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text = score.ToString();
        }
    }

}

using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
    

public class scoredisplay : MonoBehaviour
{
 

    public void addScore(float points)
    {
        score += points;
    }


    private float score;
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        scoreText.text = "Score: " + score.ToString("0");
    }



}

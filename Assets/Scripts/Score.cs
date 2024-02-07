using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    private void Start()
    {
        scoreText.text = "Score " + score.ToString();
    }
   

    public void UpdateScore(int AddScore)
    {
        score += AddScore;
        scoreText.text = "Score " + score.ToString();
    }
}

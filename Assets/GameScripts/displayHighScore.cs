using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayHighScore : MonoBehaviour
{
   
    public Text highScoreDisplay;  // public if you want to drag your text object in there manually
    public int score;

    void Update()
    {
        if (globalControl.Instance.displayHighScore)
        {
            score = globalControl.Instance.highScore;
            highScoreDisplay.text = "High Score: " + score.ToString(); // make it a string to output to the Text object
        }
    }
}

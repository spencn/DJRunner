using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class scoreCalculator : MonoBehaviour
{
    public MusicAnalyzer analyzer;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;
    public GameObject victory;
    public AudioSource audioSource;
    private int score;
    private int bpm;
    private int chroma;
    // Update is called once per frame
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        bpm = (int)(analyzer.musicVariables.bpm);
        chroma = (int)(analyzer.musicVariables.chroma);
        if (!gameOverText.activeSelf && !victory.activeSelf) //gameplay is over, get final score
        {
            if (Time.timeScale == 1)
            {
                score = score + (int)(0.01 * bpm * chroma);
                scoreText.text = score.ToString();
            }
        }
        else
        {

            globalControl.Instance.finalScore = score;
            if (globalControl.Instance.highScore < globalControl.Instance.finalScore)
            {
                globalControl.Instance.highScore = globalControl.Instance.finalScore;
            }
            globalControl.Instance.displayHighScore = true;
        }
    }
}

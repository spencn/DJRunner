using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalControl : MonoBehaviour
{
    public static globalControl Instance;
    public string filePath;
    public bool filePathSet = false;
    public AudioClip song;
    public bool songSet = false;
    public string difficulty;
    public bool difficultySet = false;
    public int highScore = 0;
    public bool displayHighScore = false;
    public float timeSongBegan;
    public int finalScore;


    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
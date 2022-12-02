using System.Collections;
using UnityEngine;
using RhythmTool;

public class Importer : MonoBehaviour
{
    public AudioImporter importer;
    public AudioSource audioSource;
    //public RhythmAnalyzer analyzer;
    public string filePath;
    public MusicAnalyzer musicAnalyzer;
    public RhythmPlayer rhythmPlayer;
    public AudioClip firstSong;
    public AudioClip secondSong;
    public AudioClip thirdSong;
    public AudioClip fourthSong;
    public AudioClip fifthSong;
    public AudioClip sixthSong;
    public RhythmData firstSongData;
    public RhythmData secondSongData;
    public RhythmData thirdSongData;
    public RhythmData fourthSongData;
    public RhythmData fifthSongData;
    public RhythmData sixthSongData;
    //add more clips here
    void Awake()
    {
        //browser.FileSelected += OnFileSelected;
        //if difficulty selected, if easy, audioSource.clip = easy.... else

        if (globalControl.Instance.difficultySet)
        {
            if (globalControl.Instance.difficulty == "song1")
            {
                audioSource.clip = firstSong;
                rhythmPlayer.rhythmData = firstSongData;
                analyzeAndPlay();
            }
            else if (globalControl.Instance.difficulty == "song2") // if medium selected
            {
                audioSource.clip = secondSong;
                rhythmPlayer.rhythmData = secondSongData;
                analyzeAndPlay();
            }
            else if (globalControl.Instance.difficulty == "song3")//hard
            {
                audioSource.clip = thirdSong;
                rhythmPlayer.rhythmData = thirdSongData;
                analyzeAndPlay();
            }
            else if (globalControl.Instance.difficulty == "song4")
            {
                audioSource.clip = fourthSong;
                rhythmPlayer.rhythmData = fourthSongData;
                analyzeAndPlay();
            }
            else if (globalControl.Instance.difficulty == "song5")
            {
                audioSource.clip = fifthSong;
                rhythmPlayer.rhythmData = fifthSongData;
                analyzeAndPlay();
            }
            else if (globalControl.Instance.difficulty == "song6")
            {
                audioSource.clip = sixthSong;
                rhythmPlayer.rhythmData = sixthSongData;
                analyzeAndPlay();
            }

            //check other clip names here
        }
        else if(globalControl.Instance.songSet) //song must be set
        {
            audioSource.clip = globalControl.Instance.song;
            analyzeAndPlay();
        }
        else //must be file path
        {
            fileSelected(globalControl.Instance.filePath);
        }
    }

    public void analyzeAndPlay()
    {
        //analyzer.Analyze(audioSource.clip);
        audioSource.Play();
        globalControl.Instance.timeSongBegan = Time.timeSinceLevelLoad;
    }

    public void fileSelected(string path)
    {
        Destroy(audioSource.clip);

        StartCoroutine(Import(path));
    }

    IEnumerator Import(string path)
    {
        importer.Import(path);

        while (!importer.isInitialized && !importer.isError)
            yield return null;

        if (importer.isError)
            Debug.LogError(importer.error);

        audioSource.clip = importer.audioClip;
        analyzeAndPlay();
    }
    public void Update()
    {
        if (audioSource.clip != null && musicAnalyzer.enabled == false)
        {
            musicAnalyzer.enabled = true;
        }
    }
}

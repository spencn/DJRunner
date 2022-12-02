using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RhythmTool;

/*
 * MusicAnalyzer
 * This script analyzes and reads the analysis file of a given mp3 in order to
 * save musical features to the MusicVariables script to be used in game
 * Note: Some code is commented out in order to preserve extra features such as volume checks
 * and live analysis of mp3 files is not available for webgl builds due to webgl restrictions
 */
public class MusicAnalyzer : MonoBehaviour
{
    // Necessary imports of Rhythm Tool scripts and Unity GameObjects
    public AudioSource audioSource;

    //public RhythmAnalyzer analyzer
    public AudioClip audioClip;
    public RhythmData rhythmData;

    public RhythmPlayer player;

    // Lists for musical features
    private List<Beat> beats;

    private List<Chroma> chroma;

    //private Track<Value> volumeTrack;
    private Track<Chroma> chromaTrack;
    public MusicVariables musicVariables;
    public bool doneAnalyzing = false;
    private bool firstLoad = true;
    private float prevTime;


    /*
     * OnEnable() is run when the GameObject tied to MusicAnalyzer is enabled
     * This is enabled when a song is selected
     * OnEnable() triggers a firstLoad, stopping other code from trying to access incomplete music variables
     * Code to live analyze and store volume data are commented out and tested for future features.
     *
     */
    private void OnEnable()
    {
        firstLoad = true;
        audioClip = audioSource.clip;
        //rhythmData = analyzer.Analyze(audioClip);
        //player.rhythmData = rhythmData;
        rhythmData = player.rhythmData;
        beats = new List<Beat>();
        chroma = new List<Chroma>();
        //volumeTrack = rhythmData.GetTrack<Value>("Volume");
        chromaTrack = rhythmData.GetTrack<Chroma>();
    }

    private void Awake()
    {
        //Testing
        //audioClip = audioSource.clip;
        //rhythmData = analyzer.Analyze(audioClip);
        //player.rhythmData = rhythmData;
        //beats = new List<Beat>();
        //chroma = new List<Chroma>();
        ////volumeTrack = rhythmData.GetTrack<Value>("Volume");
        //chromaTrack = rhythmData.GetTrack<Chroma>();


    }

    /*
     * Update is called once per frame
     * 
     */
    void Update()
    {
        //In order to stop access to unfinished data, update must check if the analysis is finished.
        if ( /*analyzer.isDone && */firstLoad == true)
        {
            //Debug.Log("Done Analyzing");
            doneAnalyzing = true;
            firstLoad = false;
            StartCoroutine(ParseMusicFeatures());
        }
    }
    /*
    * ParseMusicFeatures()
    * Clears lists of features
    * Reads features within the current runtime from the rhythmData
    * Stores the current features in musicVariables 
    * Return null: repeat this thread as long as this script is running
    */
    IEnumerator ParseMusicFeatures()
    {
        float time = audioSource.time;
        beats.Clear();
        chroma.Clear();
        rhythmData.GetFeatures<Beat>(beats, prevTime, time);
        rhythmData.GetFeatures<Chroma>(chroma, prevTime, time);
        foreach (Beat beat in beats)
        {
            //int volIndex = volumeTrack.GetIndex(beat.timestamp);
            int chromaIndex = chromaTrack.GetIndex(beat.timestamp);
            //Value volume = volumeTrack[volIndex];
            Chroma chroma = chromaTrack[chromaIndex];
            musicVariables.bpm = beat.bpm;
            //musicVariables.volume = volume.value;
            musicVariables.chroma = (float) chroma.note;
        }

        prevTime = time;
        yield return null;
    }
}

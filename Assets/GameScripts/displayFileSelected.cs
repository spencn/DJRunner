using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayFileSelected : MonoBehaviour
{
    public MusicUploader musicUploader;
    public Text fileDisplay;  // public if you want to drag your text object in there manually
    public string fileSelected;
    public Browser fileBrowser;


    void Update()
    {
        if (globalControl.Instance.difficultySet)
        {
            if (globalControl.Instance.difficulty == "song1")
            {
                fileSelected = "Vicetone&Igy - Astronomia";
            }
            else if (globalControl.Instance.difficulty == "song2")
            {
                fileSelected = "DragonForce - Through the Fire and the Flames";
            }
            else if (globalControl.Instance.difficulty == "song3")
            {
                fileSelected = "Killjoy's Theme";
            }
            else if (globalControl.Instance.difficulty == "song4")
            {
                fileSelected = "Ed Sheeran feat. Beyonce - Perfect";
            }
            else if (globalControl.Instance.difficulty == "song5")
            {
                fileSelected = "Journey - Don't Stop Believing";
            }
            else if (globalControl.Instance.difficulty == "song6")
            {
                fileSelected = "Auli'i Cravalho - How Far I'll go";
            }
        }
        else if (globalControl.Instance.songSet)
        {
            fileSelected = musicUploader.fileChosen;
        }
        else if (globalControl.Instance.filePathSet)
        {
            fileSelected = globalControl.Instance.filePath;
        } 
        
        fileDisplay.text = fileSelected; // make it a string to output to the Text object
        
        
    }
}
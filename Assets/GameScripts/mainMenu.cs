using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public Text pleaseSelectSong;
    public string warning;
    public void playGame ()
    {
        //go to next scene - is also possible to tell it to go to a specific scene, 
        //this assumes the index for the game scene is 1 higher than the index for the menu scene
        //if(globalControl.Instance.filePath != null || (globalControl.Instance.difficulty != null && globalControl.Instance.difficulty != "none"))
        if (globalControl.Instance.difficultySet || globalControl.Instance.songSet || globalControl.Instance.filePathSet)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            warning = "Please select a song to play";
            pleaseSelectSong.text = warning;
        }
        
    }
    public void quitGame()
    {
        
        // Runtime code here
#if UNITY_EDITOR
        // Editor specific code here
        EditorApplication.ExitPlaymode();
#endif
        // Runtime code here
        Application.Quit();

    }



}

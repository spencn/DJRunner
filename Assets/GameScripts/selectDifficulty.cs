using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectDifficulty : MonoBehaviour
{
    public GameObject warningText;
    public void selectSong1()
    {
        globalControl.Instance.difficulty = "song1";
        setVars();
    }
    public void selectsong2()
    {
        globalControl.Instance.difficulty = "song2";
        setVars();
    }

    public void selectSong3()
    {
        globalControl.Instance.difficulty = "song3";
        setVars();
    }
    public void selectSong4()
    {
        globalControl.Instance.difficulty = "song4";
        setVars();
    }
    public void selectSong5()
    {
        globalControl.Instance.difficulty = "song5";
        setVars();
    }
    public void selectSong6()
    {
        globalControl.Instance.difficulty = "song6";
        setVars();
    }

    public void setVars()
    {
        globalControl.Instance.difficultySet = true;
        globalControl.Instance.songSet = false;
        warningText.SetActive(false);
    }



}

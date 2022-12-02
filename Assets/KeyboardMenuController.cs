using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardMenuController : MonoBehaviour
{
    public GameObject difficultyFirstbutton, uploadFirstButton, mainMenuButton, buttonHTP;

    public void beginUpload()
    {
        //clear first object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(uploadFirstButton);
    }
    public void beginHTP()
    {
        //clear first object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(buttonHTP);
    }
    public void beginDiff()
    {
        // clear first object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(difficultyFirstbutton);
    }
    public void mainMenu()
    {
        // clear first object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(mainMenuButton);
    }
}

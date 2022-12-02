
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class MusicUploader : MonoBehaviour
{
    public string fileChosen;
    public GameObject mainMenu;
    public GameObject currentMenu;
    public GameObject warningText;
    public KeyboardMenuController keyboardScript;
    [DllImport("__Internal")] private static extern void musicUploaderCaptureClick();
    IEnumerator LoadTexture(string url)
    {
        fileChosen = url;
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //send audio clip to globalControl script
                AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
                globalControl.Instance.song = clip;
                globalControl.Instance.difficultySet = false;
                globalControl.Instance.songSet = true;
                keyboardScript.mainMenu();
                warningText.SetActive(false);
                currentMenu.SetActive(false);
                mainMenu.SetActive(true);
            }
        }
    }

    void FileSelected(string url)
    {
        StartCoroutine(LoadTexture(url));
    }

    public void OnButtonPointerDown()
    {
        musicUploaderCaptureClick();
    }
}

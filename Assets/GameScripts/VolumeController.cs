using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public volumeBar Vbar;
    public MusicVariables musicVariables;
    public AudioSource audioSource;
    private float volume = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        volume = audioSource.volume;
        Vbar.SetMaxVolume(0.9f);
        Vbar.SetVolume(audioSource.volume);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(audioSource.volume < 0.9f)
            {
                audioSource.volume += 0.1f;
                Vbar.SetVolume(audioSource.volume);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (audioSource.volume > 0.1f)
            {
                audioSource.volume -= 0.1f;
                Vbar.SetVolume(audioSource.volume);
            }
        }
        //Debug.Log("Current Volume = " + audioSource.volume);
        volume = audioSource.volume;
        musicVariables.volume = volume;
    }
}

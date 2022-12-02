using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public AudioSource audioSource;
    void Start()
    {
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Time.timeSinceLevelLoad/(audioSource.clip.length + globalControl.Instance.timeSongBegan);
    }
}

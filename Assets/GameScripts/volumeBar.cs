using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeBar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxVolume (float vol)
    {
        slider.maxValue = vol;
        slider.value = vol;
    }
    public void SetVolume(float vol)
    {
        slider.value = vol;
    }
}

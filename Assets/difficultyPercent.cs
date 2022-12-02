using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficultyPercent : MonoBehaviour
{
    
    public fanSpawn fS;
    public AudioSource audioSource;
    private float total;
    private float percent;
    // Start is called before the first frame update
    void Start()
    {
        fS.difficulty = 1;
        total = audioSource.clip.length;
        
    }

    // Update is called once per frame
    void Update()
    {
        percent = (Time.timeSinceLevelLoad / total)  * 100f;
        if (percent > 25 && percent < 50)
        {
            fS.difficulty = 2;
        }
        else if (percent >= 50 && percent < 75)
        {
            fS.difficulty = 3;
        } else if (percent >= 75 && percent < 100)
        {
            fS.difficulty = 4;
        }
    }
}

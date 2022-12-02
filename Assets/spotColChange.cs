using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotColChange : MonoBehaviour
{
    public MusicVariables musics;
    public MusicAnalyzer musicAnalayzer;
    public float changeRate = 1;
    private bool firstLoad = true;
    private SpriteRenderer rend;
    private float BPM;
    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
        changeRate = musics.bpm / 60;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (musics.bpm < 40)
        {
            BPM = 40;
        }
        else
        {
            BPM = musics.bpm;
        }
        changeRate = BPM / 60;
        if (musicAnalayzer.doneAnalyzing && firstLoad == true)
        {
           
            
            StartCoroutine(changeCol());
            firstLoad = false;
        }
    }
    IEnumerator changeCol()
    {
        int rand;
        while (true) {
           
            
            yield return new WaitForSeconds(changeRate);
            
            rand = Random.Range(0, 5);
            
            switch (rand)
            {
                case 0:
                    rend.color = Color.red;
                    break;
                case 1:
                    rend.color = Color.white;
                    break;
                case 2:
                    rend.color = Color.blue;
                    break;
                case 3:
                    rend.color = Color.green;
                    break;
                case 4:
                    rend.color = Color.cyan;
                    break;
                case 5:
                    rend.color = Color.magenta;
                    break;
            }
        }
    }
}

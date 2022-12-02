using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RhythmTool;

public class fanSpawn : MonoBehaviour
{
    public GameObject fanPrefab;
    public Sprite[] _fanSprites;
    public MusicVariables musics;
    private Vector2 screenBounds;
    public int difficulty;
    private bool spawn;
    private float radius;
    private float spawnrate;
    public MusicAnalyzer musicAnalayzer;
    private bool firstLoad = true;
    private float BPM;

    // Start is called before the first frame update
    void Start()
    {
        firstLoad = true;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        radius = musics.chroma;
        spawnrate = musics.bpm/60;
        

    }

    /*
    * Update is called once per frame
    * 
    */
    void Update()
    {
        BPM = musics.bpm;
        spawnrate = BPM / 240;
        if(/*musicAnalayzer.doneAnalyzing && */firstLoad == true)
        {
            StartCoroutine(FanWave());
            firstLoad = false;
            
        }
    }
    /*
    * spawnFan(int): int moveID between 1-2
    * Called from within the fanSpawn coroutine
    * Creates a fan object if a BPM is present with the requirements from the music
    * Generate random sprite, scaled to the pitch, randomly outside of the players view
    */
    private void spawnFan(int moveID)
    {
        if(musics.bpm == 0) //Do not spawn if no beat is present
        {
            return;
        }
        GameObject fan = Instantiate(fanPrefab) as GameObject;
        fan.GetComponent<SpriteRenderer>().sprite = _fanSprites[Random.Range(1, 4)];
        fan.GetComponent<Fan_movement>().musics = musics;
        fan.GetComponent<Fan_movement>().ID = moveID;
        radius = musics.chroma + 1; // Store the chroma as radius, add 1 to remove 0 indexing
        fan.transform.localScale = new Vector3(radius*.35f, radius*.35f, radius*.35f);
        fan.transform.position = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + 100);
    }
    
    /*
    * despawnFan()
    * Called from within the fanSpawn coroutine
    * Cycles through each off screen Game Object tagged "Fan"
    * If they are offscreen, adjusted to their own size, remove them
    */
    private void despawnFan()
    {
        GameObject[] offscreen = GameObject.FindGameObjectsWithTag("Fan");
        foreach (GameObject goneFan in offscreen)
        {
            Transform fanTran = goneFan.GetComponent<Transform>();
            // Checking localScale ensures the fan is no longer visible
            if (fanTran.position.y + fanTran.localScale.y / 2 < -screenBounds.y)
                Destroy(goneFan);
        }
    }
    /*
    * FanWave()
    * Calls spawnFan with the given moveID and despawnFan when finished
    * Return wait: Repeat this coroutine on beat and while this script is still running
    */
    IEnumerator FanWave()
    {
        int ID = 1;
        while (true)
        {
            yield return new WaitForSeconds(spawnrate);
            switch (difficulty){
                case 1:
                    spawnFan(1);
                    break;
                case 2:
                    spawnFan(2);
                    break;
                case 3:
                    spawnFan(ID);
                    break;
            }           
            despawnFan();
            if (ID == 1)
            {
                ID++;
            } else
            {
                ID--;
            }
        }
    }
}


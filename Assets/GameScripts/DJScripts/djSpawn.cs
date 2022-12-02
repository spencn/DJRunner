using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class djSpawn : MonoBehaviour
{
    public HealthBar healthbar;
    public MusicVariables musics;
    public AudioSource audioSource;
    public GameObject gameOverText;
    public BatterySpawner batterySpawner;
    public GameObject DJ;
    public Image batteryRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spawnDJ();
    }
    private void spawnDJ()
    {
        GameObject dj = Instantiate(DJ) as GameObject;
        dj.GetComponent<DjLife>().healthBar = healthbar;
        dj.GetComponent<DJ_movement>().musics = musics;
        dj.GetComponent<DjLife>().batterySpawner = batterySpawner;
        dj.GetComponent<DjLife>().batteryRender = batteryRenderer;
        dj.transform.position = new Vector3(0, -3);
    }
    // Update is called once per frame
    void Update()
    {
       if (healthbar.slider.value == 0)
        {
            gameOver();
        }
    }
    public void gameOver()
    {
        Time.timeScale = 0;
        audioSource.Pause();
        globalControl.Instance.displayHighScore = true; //high score will be displayed in the menu
        //if (globalControl.Instance.highScore < score) globalControl.Instance.highScore = score.... or something- when we have a score var somewhere
        gameOverText.SetActive(true);

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pause_restart_detectSongEnd : MonoBehaviour
{
	public AudioSource audioSource;
	public GameObject gameOverText;
	public GameObject victory;
	public Text score;
	public GameObject healthBar;
	public GameObject volumeBar;
	public GameObject progressBar;
    public GameObject batteryHUD;
	public Slider healthSlider;
    public GameObject DJ;
	public GameObject scoreText;

	// Use this for initialization
	void Start()
	{
        DJ = GameObject.FindGameObjectWithTag("Player");
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update()
	{
        if (Input.GetKeyDown(KeyCode.L))
        {
            healthBar.SetActive(false);
            volumeBar.SetActive(false);
            progressBar.SetActive(false);
            batteryHUD.SetActive(false);
            victory.SetActive(true);
        }
        
		//uses the p button to pause and unpause the game
		if (Input.GetKeyDown(KeyCode.P) && !gameOverText.activeSelf && !victory.activeSelf)
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				audioSource.Pause();
				
			}
			else if (Time.timeScale == 0)
			{
				//Debug.Log("high");
				Time.timeScale = 1;
				audioSource.Play(0);
	

			}
		}

		if (Input.GetKeyDown(KeyCode.M))
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		}

		if (audioSource.clip != null)
		{
			if ((Time.timeSinceLevelLoad)  > (audioSource.clip.length + globalControl.Instance.timeSongBegan)) //if the song is over
			{
				
																
				if (!victory.activeSelf){

                    Destroy(DJ);
					audioSource.Pause();

					healthBar.SetActive(false);
					volumeBar.SetActive(false);
					progressBar.SetActive(false);
                    batteryHUD.SetActive(false);
					scoreText.SetActive(false);

					//score.text = whatever the score is
					
					//score.text += "0";
					victory.SetActive(true);
					float finalScore = globalControl.Instance.finalScore;

					score.text = finalScore.ToString();

				}
			}
		}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DjLife : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public int maxCharge = 100;
    public int currentCharge;
    public AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip deathSound;
    public HealthBar healthBar;
    public BatterySpawner batterySpawner;
    public bool isInvincible = false;
    public Image batteryRender;
    public Sprite[] sprite = new Sprite[5];
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Fan" && !isInvincible)
        {
            if(collider.GetComponent<Fan_movement>().ID != 3)
            {
                Destroy(collider.gameObject);
                takeDamage();
            } else
            {
                takeDamage();
            }
            
            
        }else if(collider.tag == "Battery")
        {
            int tempCharge = currentCharge + batterySpawner.rechargeAmount;
            if(tempCharge>100)
            {
                tempCharge = 100;
            }
            currentCharge = tempCharge;
            switch (currentCharge)
            {
                case 0:
                    batteryRender.sprite = sprite[0];
                    break;
                case 25:
                    batteryRender.sprite = sprite[1];
                    break;
                case 50:
                    batteryRender.sprite = sprite[2];
                    break;
                case 75:
                    batteryRender.sprite = sprite[3];
                    break;
                case 100:
                    batteryRender.sprite = sprite[4];
                    break;
            }
            Destroy(collider.gameObject);
            batterySpawner.numOfBatteries = batterySpawner.numOfBatteries - 1;
        }
        
    }
    public void takeDamage()
    {
        currentHealth--;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            Debug.Log("You got caught!");
            audioSource.PlayOneShot(deathSound);
            //audioSource.Play();
        } else
        {
            audioSource.PlayOneShot(hitSound);
            //audioSource.Play();
        }
        
    }
}

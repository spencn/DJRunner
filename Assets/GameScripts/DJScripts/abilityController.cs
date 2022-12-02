using System.Collections;
using UnityEngine;

public class abilityController : MonoBehaviour
{
    public GameObject Dj;
    public GameObject[] Djbody;
    public GameObject singRing;
    public bool invincible;
    public DjLife djLife;
    // Start is called before the first frame update
    void Start()
    {
        invincible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //SING RING ABILITY
        if (Input.GetKeyDown(KeyCode.Space) && !singRing.activeSelf && !invincible && djLife.currentCharge>=25)
        {
            djLife.currentCharge = djLife.currentCharge - 25;
            switch (djLife.currentCharge)
            {
                case 0:
                    djLife.batteryRender.sprite = djLife.sprite[0];
                    break;
                case 25:
                    djLife.batteryRender.sprite = djLife.sprite[1];
                    break;
                case 50:
                    djLife.batteryRender.sprite = djLife.sprite[2];
                    break;
                case 75:
                    djLife.batteryRender.sprite = djLife.sprite[3];
                    break;
            }
            singRing.SetActive(true);
        }
        //INVINCIBLE ABILITY
        //DISABED - will be enable on multiple DJ picking 
        /*
        else if (Input.GetKeyDown("q") && !singRing.activeSelf && !invincible && djLife.currentCharge >= 25)
        {
            djLife.currentCharge = djLife.currentCharge - 25;
            switch (djLife.currentCharge)
            {
                case 0:
                    djLife.batteryRender.sprite = djLife.sprite[0];
                    break;
                case 25:
                    djLife.batteryRender.sprite = djLife.sprite[1];
                    break;
                case 50:
                    djLife.batteryRender.sprite = djLife.sprite[2];
                    break;
                case 75:
                    djLife.batteryRender.sprite = djLife.sprite[3];
                    break;
            }
            StartCoroutine(InTheZone());
        }
        */
    }

    IEnumerator InTheZone()
    {
        int secondsWaited = 0;
        invincible = true;
        Dj.GetComponent<SpriteRenderer>().color = Color.cyan;
        Djbody[0].GetComponent<SpriteRenderer>().color = Color.cyan;
        Djbody[1].GetComponent<SpriteRenderer>().color = Color.cyan;
        
        djLife.isInvincible = true;
        while (secondsWaited < 6)
        {
            Debug.Log("waited " + secondsWaited);
            yield return new WaitForSeconds(1);
            secondsWaited++;
        }
        invincible = false;
        Dj.GetComponent<SpriteRenderer>().color = Color.white;
        Djbody[0].GetComponent<SpriteRenderer>().color = Color.white;
        Djbody[1].GetComponent<SpriteRenderer>().color = Color.white;
        //Dj.GetComponent<CircleCollider2D>().enabled = true;
        djLife.isInvincible = false;

        

    }
}

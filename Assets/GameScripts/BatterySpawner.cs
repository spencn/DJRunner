using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySpawner : MonoBehaviour
{
    public float numToSpawn;
    public float numOfBatteries;
    public GameObject battery;
    public GameObject quad;
    public float batteryDelay;
    public int rechargeAmount;

    private void Update()
    {
        if(numOfBatteries < numToSpawn)
        {
            numOfBatteries++;
            StartCoroutine(SpawnCoroutine(batteryDelay));
        }
    }

    public void spawnBattery()
    {

            float screenX;
            float screenY;
            MeshCollider c = quad.GetComponent<MeshCollider>();
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            Vector2 pos = new Vector2(screenX, screenY);
            Instantiate(battery, pos, battery.transform.rotation);
    }

    private IEnumerator SpawnCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        spawnBattery();
    }
}

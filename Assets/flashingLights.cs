using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashingLights : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer flash;

    void Start()
    {
        flash = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        flash.color = new Color(Random.Range(67, 255 - 67), Random.Range(67, 255 - 67), Random.Range(67, 255 - 67));
    }
}

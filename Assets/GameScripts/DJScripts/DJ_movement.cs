using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJ_movement : MonoBehaviour
{
    public float speed;
    public MusicVariables musics;
    // Start is called before the first frame update
    void Start()
    {
        speed = musics.volume * 20f;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            
            if (pos.y >= 0.7)
            {
                pos.y = 0.7f;
            }
            else
            {
                pos.y += speed * Time.deltaTime;
            }
        }
        if (Input.GetKey("s"))
        {
            if(pos.y <= -4.7f)
            {
                pos.y = -4.7f;
            } else
            {
                pos.y -= speed * Time.deltaTime;
            }
            
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKeyDown("f"))
        {
            Debug.Log(pos);
        }

        transform.up = pos - transform.position;
     
        transform.position = pos;
        setSpeed(musics.volume);
        
    }
    public void setSpeed(float vol)
    {
        speed = vol*11f;
    }
}

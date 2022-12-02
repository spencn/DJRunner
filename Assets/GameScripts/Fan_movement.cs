using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_movement : MonoBehaviour
{
    public MusicVariables musics;
    public int ID;
    public float speed;
    
    
    
    GameObject dj;
    Vector3 currDjPos;
    Vector3 move;
    private float step;
    // Start is called before the first frame update
    void Start()
    {

        dj = GameObject.FindGameObjectWithTag("Player");
        currDjPos = dj.transform.position;

        move = currDjPos - transform.position;
        //STATIC FAN SPEED - best for  CHASING movement
        //speed = musics.volume * 7.5f;
        step = speed * Time.deltaTime;

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 moveDirection;
        //ROTATE
        if (ID != 3)
        {

            if (ID == 2)
            {
                if (pos.y > dj.transform.position.y)
                {
                    moveDirection = dj.transform.position - pos; //follow the DJ
                }
                else
                {
                    moveDirection = Vector3.down;
                }
            }
            else
            {
                
               moveDirection = pos + move;
                
            }
            // make z part of the vector 0 as we dont need it
            moveDirection.z = 0;
            // normalize the vector so its in units of 1
            moveDirection.Normalize();
            // if we have moved and need to rotate
            if (moveDirection != Vector3.zero)
            {
                // calculates the angle we should turn towards, + 90 makes the sprite rotate
                float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + 90;
                // actually rotates the sprite using Slerp (from its previous rotation, to the new one at the designated speed.
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), 20 * Time.deltaTime);
            }
        }
        
        // DYNAMIC FAN SPEED - best for LINEAR movement
        speed = musics.volume * 7.5f;
        if (ID == 1)
        {
            transform.position = Vector3.MoveTowards(pos, pos + Vector3.Normalize(move), step);
            
        } else if (ID == 2)
        {           
            step = speed * Time.deltaTime;
            if (pos.y > dj.transform.position.y)
            {
                transform.position = Vector3.MoveTowards(pos, dj.transform.position, step);
            }
            else
            {
                pos.y -= speed * Time.deltaTime;
                transform.position = pos;
            }
        }
        //Vector3 vectorToTarget = dj.transform.position - transform.position;
        //float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Euler(0, 0, angle);

        /* FUN CODE - THINGIES FOLLOW INSTEAD OF RUN AT DESIGNATED PATH
        Vector3 pos = transform.position;
        float step = speed * Time.deltaTime;
        
        if (pos.y > dj.transform.position.y)
        {
            transform.position = Vector3.MoveTowards(pos, dj.transform.position, step);
        }
        else
        {
            pos.y -= speed * Time.deltaTime;
            transform.position = pos;
        }
        */
    }
    
}

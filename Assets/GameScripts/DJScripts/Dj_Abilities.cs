using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dj_Abilities : MonoBehaviour
{
    public GameObject singRing;
    public float size = 1;
    public float sizeGrow = 0.05f;
    public float sizeMax = 5;

    Collider2D coll;
    // Start is called before the first frame update
    void OnEnable()
    {
        size = 1;
        coll = GetComponent<CircleCollider2D>();
        singRing.transform.localScale = new Vector3(size, size, size);
        coll.enabled = true;
        Debug.Log("Collider.enabled = " + coll.enabled);
        
    }

    // Update is called once per frame
    void Update()
    {
        singRing.transform.localScale = new Vector3(size, size, size);
        size += sizeGrow;
        if (size > sizeMax)
        {
            coll.enabled = false;
            Debug.Log(coll.enabled);
            singRing.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Fan" && collider.GetComponent<Fan_movement>().ID != 3)
        {
            
            Destroy(collider.gameObject);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f, +1f)]
    public float scrollSpeed = 0.5f;
    public GameObject dj;
    private float offset;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        dj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dj = GameObject.FindGameObjectWithTag("Player");
        scrollSpeed = dj.GetComponent<DJ_movement>().speed;
        offset += (Time.deltaTime * scrollSpeed) / 20f;
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));

    }
}

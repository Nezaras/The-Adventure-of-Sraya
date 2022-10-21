using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_airmancur : MonoBehaviour
{
    public float speedX = 0.1f;
    public float speedY = 0.1f;
    private float curX;
    private float curY;
    private Renderer rend;

    private void Awake()
    {
        curX = GetComponent<Renderer>().material.mainTextureOffset.x;
        curY = GetComponent<Renderer>().material.mainTextureOffset.y;
    }

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        curX += Time.time * speedX;
        curY += Time.time * speedY;
        rend.material.SetTextureOffset("_MainTex", new Vector2(curX, curY));
    }
}

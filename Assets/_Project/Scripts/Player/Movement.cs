using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private GameObject player;
    private GameObject moveText;

    private Text timeoutText;

    public float timeout = 2.0f;

    private bool lookingObject = false;

    void Start()
    {
        init();
    }

    void Update()
    {
        if (lookingObject)
        {
            timeout -= Time.deltaTime;

            timeoutText.text = timeout.ToString("0.##");

            if (timeout <= 0.0f)
            {
                movePlayer();
                
                hideText();
            }
        }
    }

    void init()
    {
        player = GameObject.Find("Player");
        moveText = GameObject.Find("Movement");
        
        timeoutText = GameObject.Find("MovementTimeoutText").GetComponent<Text>();
        
        Invoke("hideText", 0.01f);
    }

    public void showText()
    {
        moveText.SetActive(true);

        lookingObject = true;
    }

    public void hideText()
    {
        moveText.SetActive(false);

        lookingObject = false;

        timeout = 2.0f;
    }

    public void movePlayer()
    {
        player.transform.position = new Vector3(gameObject.transform.position.x, 1, gameObject.transform.position.z);
    }
}

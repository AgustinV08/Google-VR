using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public float timeout = 2.0f;
    
    private Text timeoutText;

    private bool play = false;
    private bool quit = false;

    // Start is called before the first frame update
    void Start()
    {
        timeoutText = GameObject.Find("Timeout").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (play || quit)
        {
            timeout -= Time.deltaTime;
            
            timeoutText.text = timeout.ToString("0.##");

            if (timeout <= 0.0f)
            {
                if (play)
                {
                    Play();
                }

                if (quit)
                {
                    Quit();
                }

                timeout = 2.0f;
            }
        }
    }

    public void StartPlay()
    {
        play = true;
        timeout = 2.0f;
        
        timeoutText.gameObject.SetActive(true);
    }
    
    public void StartQuit()
    {
        play = true;
        timeout = 2.0f;
        
        timeoutText.gameObject.SetActive(true);
    }

    public void StopLooking()
    {
        play = false;
        quit = false;
        timeout = 2.0f;
        
        timeoutText.gameObject.SetActive(false);
    }

    void Play()
    {
        SceneManager.LoadScene("Dev");
    }

    void Quit()
    {
        Application.Quit();
    }
}

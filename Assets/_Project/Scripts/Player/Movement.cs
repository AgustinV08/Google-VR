using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private GameObject player;

    public Text moveText;
    
    void Start()
    {
        init();
    }

    void init()
    {
        player = GameObject.Find("Player");
    }

    public void showText()
    {
        moveText.gameObject.SetActive(true);
    }

    public void hideText()
    {
        moveText.gameObject.SetActive(false);
    }

    public void movePlayer()
    {
        player.transform.position = new Vector3(gameObject.transform.position.x, 1, gameObject.transform.position.z);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public int health = 5;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        
        Debug.Log(health);

        if (health <= 0)
        {
            death();
        }
    }

    public void death()
    {
        Shoot player = GameObject.Find("Player").GetComponent<Shoot>();
        
        player.stopTimeout();
        
        gameObject.SetActive(false);
    }
}

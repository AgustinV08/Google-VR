using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 5;

    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider = GameObject.Find("PlayerHealth").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void TakeDamage(int damage)
    {
        health -= damage;

        healthSlider.value = health;

        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("Finish");
    }
}

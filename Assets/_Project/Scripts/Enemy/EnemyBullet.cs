using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 1;

    private float timeout = 10.0f;

    void Update()
    {
        timeout -= Time.deltaTime;

        if (timeout <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("MainCamera"))
        {
            other.gameObject.GetComponent<Player>().TakeDamage(damage);

            gameObject.SetActive(false);
        }
    }
}

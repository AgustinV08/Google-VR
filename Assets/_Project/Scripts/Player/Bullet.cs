﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;

    private float timeout = 5.0f;

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
        if (other.collider.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().takeDamage(damage);

            gameObject.SetActive(false);
        }
    }
}

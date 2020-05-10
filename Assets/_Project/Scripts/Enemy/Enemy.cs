using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;

    public GameObject player;
    private GameObject bulletPrefab;

    private List<GameObject> bulletPool = new List<GameObject>();

    public float shootTimeout = 2.0f;
    
    GameObject generateBullet()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if(bulletPool[i].activeSelf == false)
            {
                bulletPool[i].SetActive(true);
                bulletPool[i].transform.position = transform.position;
                bulletPool[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                return bulletPool[i];
            }
        }
		
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletPool.Add(bullet);
        return bullet;
    }
    
    void Start()
    {
        init();
    }

    void Update()
    {
        gameObject.transform.LookAt(player.transform);

        shootTimeout -= Time.deltaTime;

        if (shootTimeout <= 0)
        {
            Shoot();
            shootTimeout = 2.0f;
        }
    }

    void init()
    {
        player = GameObject.Find("Player");
        bulletPrefab = Resources.Load<GameObject>("EnemyBullet");
    }

    void Shoot()
    {
        GameObject bullet = generateBullet();
        bullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 1000);
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
        player.GetComponentInChildren<Shoot>().stopTimeout();
        
        gameObject.SetActive(false);
    }
}

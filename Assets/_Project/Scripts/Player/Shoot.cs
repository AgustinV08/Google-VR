using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    private GameObject bulletPrefab;
    private List<GameObject> bulletPool = new List<GameObject>();
    private GameObject shootText;

    private Text timeoutText;
    
    public float timeout = 2.0f;

    private bool lookingEnemy = false;

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
        if (lookingEnemy)
        {
            timeout -= Time.deltaTime;

            timeoutText.text = timeout.ToString("0.##");

            if (timeout <= 0.0f)
            {
                shootEnemy();

                timeout = 2.0f;
            }
        }
    }

    void init()
    {
        bulletPrefab = Resources.Load<GameObject>("PlayerBullet");
        shootText = GameObject.Find("Shooting");
        
        timeoutText = GameObject.Find("ShootTimeoutText").GetComponent<Text>();
        
        stopTimeout();
    }

    public void shootEnemy()
    {
        GameObject bullet = generateBullet();
        bullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 1000);
    }

    public void startTimeout()
    {
        shootText.SetActive(true);

        lookingEnemy = true;
    }
    
    public void stopTimeout()
    {
        shootText.SetActive(false);
        
        lookingEnemy = false;

        timeout = 2.0f;
    }
}

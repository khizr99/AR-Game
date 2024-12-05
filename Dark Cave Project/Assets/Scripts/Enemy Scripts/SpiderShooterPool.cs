using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooterPool : MonoBehaviour
{
    [SerializeField]
    private GameObject spiderBullet;

    private List<GameObject> bullets = new List<GameObject>();

    [SerializeField]
    private int initialBullets = 20;

    [SerializeField]
    private Transform bulletSpawnPos;

    [SerializeField]
    private float minShootWaitTime = 1f, maxShootWaitTime = 3f;

    private float waitTime;

    private void Awake()
    {
        CreateInitialBullets();
    }

    private void Start()
    {
        waitTime = Time.time + Random.Range(minShootWaitTime, maxShootWaitTime);
    }

    private void Update()
    {
        if (Time.time > waitTime)
        {
            waitTime = Time.time + Random.Range(minShootWaitTime, maxShootWaitTime);
            Shoot();
        }
    }

    void CreateInitialBullets()
    {

        for (int i = 0; i < initialBullets; i++)
        {
            GameObject newBullet = Instantiate(spiderBullet);
            newBullet.SetActive(false);
            newBullet.transform.SetParent(transform);
            bullets.Add(newBullet);
        }

    }

    void Shoot()
    {
        //for (int i = 0; i < bullets.Count; i++)
        //{
        //    if (!bullets[i].activeInHierarchy)
        //    {
        //        bullets[i].SetActive(true);
        //        bullets[i].transform.position = bulletSpawnPos.position;
        //        break;
        //    }
        //}

        foreach (GameObject bul in bullets)
        {
            if (!bul.activeInHierarchy)
            {
                bul.SetActive(true);
                bul.transform.position = bulletSpawnPos.position;
                break;
            }
        }

    }

} // class























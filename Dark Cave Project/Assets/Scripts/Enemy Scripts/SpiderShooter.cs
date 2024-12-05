using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : MonoBehaviour
{

    [SerializeField]
    private GameObject spiderBullet;

    [SerializeField]
    private Transform bulletSpawnPos;

    [SerializeField]
    private float minShootWaitTime = 1f, maxShootWaitTime = 3f;

    private float waitTime;

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

    void Shoot()
    {
        Instantiate(spiderBullet, bulletSpawnPos.position, Quaternion.identity);
    }




} // class




































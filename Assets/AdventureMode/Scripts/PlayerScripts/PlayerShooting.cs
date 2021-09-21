using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    float cooldownTimer = 0;
    int bulletLayer;

    void Start()
    {
        bulletLayer = gameObject.layer;
    }

    void Update()
    {
        //shooting based on bullet power
        cooldownTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            //getting bullet power, for different type of bullets
            int bulletpower = gameObject.GetComponent<PlayerCollisionHandler>().bulletPower;
            switch (bulletpower)
            {
                case 1:
                    GameObject bulletGO = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, -90));
                    float fireDelay = bulletPrefab.GetComponent<BulletScript>().delay;
                    cooldownTimer = fireDelay;
                    bulletGO.layer = bulletLayer;
                    break;
                default: break;
            }
        }
    }
}

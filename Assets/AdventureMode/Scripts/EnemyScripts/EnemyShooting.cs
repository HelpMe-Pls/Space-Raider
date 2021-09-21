using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public float fireDelay = 2f;
    public float cooldownTimer = 0;

    Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    int bulletLayer;
    Transform player;

    void Start()
    {
        bulletLayer = gameObject.layer;
    }

    // For EnemyShip03, shoot where they are facing
    void Update()
    {
        
        //now shoot
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * bulletOffset;
            GameObject bulletGO = Instantiate(enemyBulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
    }
}

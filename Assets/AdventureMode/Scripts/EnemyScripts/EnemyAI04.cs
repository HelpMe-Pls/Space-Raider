using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI04 : MonoBehaviour
{
    public Transform player;
    float rotSpeed = 180f;
    void Start()
    {
        
    }

    void Update()
    {
        //search for player
        if (player == null)
        {
            GameObject go = GameObject.Find("Player");
            if (go != null) player = go.transform;
        }
        if (player == null) return;
        //face player
        if (Vector3.Distance(transform.position, player.position) < 15)
        {
            Vector3 dir = player.position - transform.position;
            dir.Normalize();
            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
        }
    }
}

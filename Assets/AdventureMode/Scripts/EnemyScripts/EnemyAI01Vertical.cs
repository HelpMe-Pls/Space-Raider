using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI01Vertical : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.Find("Player");
            if (go != null) player = go.transform;
        }
        if (player == null) return;
        if (Vector3.Distance(transform.position, player.position) < 17)
        {
            Vector3 pos = transform.position;
            pos.y -= speed * Time.deltaTime;
            transform.position = pos;
        }
    }
}

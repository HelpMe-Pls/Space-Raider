using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI01 : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    void Start()
    {

    }
    // move to the left side of the screen
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
            pos.x -= speed * Time.deltaTime;
            transform.position = pos;
        }
    }
}

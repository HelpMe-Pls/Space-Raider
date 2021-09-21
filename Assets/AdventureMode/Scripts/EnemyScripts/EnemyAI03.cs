using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI03 : MonoBehaviour
{
    Transform player;
    public float speed = 7f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Simple homing to the player
    void Update()
    {
        //search for player
        if (player == null)
        {
            GameObject go = GameObject.Find("Player");
            if (go != null) player = go.transform;
        }
        if (player == null) return;
        //home at the player
        if (Vector3.Distance(transform.position, player.position) < 15)
        {
            Vector3 pos = transform.position;
            pos.x -= speed * Time.deltaTime;

            if (pos.y < player.transform.position.y) pos.y += speed * Time.deltaTime;
            else pos.y -= speed * Time.deltaTime;

            transform.position = pos;
        }
    }
}

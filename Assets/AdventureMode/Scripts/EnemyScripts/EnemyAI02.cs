using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI02 : MonoBehaviour
{
    public float speed = 5f;
    public Transform player;
    float frequency = 20.0f;  // Speed of sine movement
    float magnitude = 0.25f;   // Size of sine movement
    Vector3 axis;

    void Start()
    {
        axis = transform.right;
    }

    // Sine wave pattern
    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.Find("Player");
            if (go != null) player = go.transform;
        }
        if (player == null) return;
        if (Vector3.Distance(transform.position, player.position) < 15 && Time.timeScale != 0f)
        {
            Vector3 pos = transform.position;
            pos += transform.up * Time.deltaTime * speed;
            transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
        }
    }
}

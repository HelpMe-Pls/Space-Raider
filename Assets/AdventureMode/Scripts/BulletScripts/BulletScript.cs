using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float damage = 1;
    public float maxSpeed = 10f;
    public float delay = 0.4f;

    // Moving the bullet
    void Update()
    {
        Vector3 pos = transform.position;
        pos += transform.rotation * new Vector3(0, maxSpeed * Time.deltaTime, 0);
        transform.position = pos;
    }

}

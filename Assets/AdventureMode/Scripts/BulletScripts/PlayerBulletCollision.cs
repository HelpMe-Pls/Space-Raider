using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag != "Finish")
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}

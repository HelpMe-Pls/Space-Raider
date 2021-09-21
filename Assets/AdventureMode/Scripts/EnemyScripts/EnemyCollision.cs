using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float health = 1f;
    float invulnTimer = 0;
    int correctLayer;

    //get hit by bullet
    void OnTriggerEnter2D(Collider2D col)
    {
        if (invulnTimer <= 0 && col.gameObject.tag == "Weapon")
        {
            float damage = col.GetComponent<BulletScript>().damage;
            health = health - damage;
            invulnTimer = 2f;
            gameObject.layer = 11;
        }
    }

    void Start()
    {
        correctLayer = gameObject.layer;
    }
    //Invincibility frames and destroyed by player bullets
    void Update()
    {
        invulnTimer -= Time.deltaTime;
        if (invulnTimer <= 0)
        {
            gameObject.layer = correctLayer;
        }
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}

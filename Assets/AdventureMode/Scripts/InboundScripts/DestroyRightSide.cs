using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRightSide : MonoBehaviour
{
    float bulletRadius = 1f;

    void DestroyBulletOffScreen()
    {
        Vector3 pos = transform.position;
        Camera mainCamera = Camera.main;
        Vector3 cameraPosition = mainCamera.transform.position;
        //assuming bullets only move from left to right
        float xDist = mainCamera.aspect * mainCamera.orthographicSize;
        float xMax = cameraPosition.x + xDist;

        if ( pos.x + bulletRadius > xMax)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        DestroyBulletOffScreen();
    }
}

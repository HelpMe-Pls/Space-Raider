using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLeftSide : MonoBehaviour
{
    float enemyRadius = 1f;

    void DestroyOffScreen()
    {
        Vector3 pos = transform.position;
        Camera mainCamera = Camera.main;
        Vector3 cameraPosition = mainCamera.transform.position;

        float xDist = mainCamera.aspect * mainCamera.orthographicSize;
        float xMin = cameraPosition.x - xDist;

        if (pos.x - enemyRadius < xMin)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        DestroyOffScreen();
    }
}

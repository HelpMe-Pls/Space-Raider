using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDownward : MonoBehaviour
{
    void Update()
    {
        destroyDownward();
    }
    void destroyDownward()
    {
        Vector3 pos = transform.position;
        Camera mainCamera = Camera.main;

        float yMax = mainCamera.orthographicSize;

        if (pos.y < -yMax)
        {
            Destroy(gameObject);
        }
    }
}

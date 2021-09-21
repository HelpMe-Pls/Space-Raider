using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVertical : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        destroyVertical();
    }

    void destroyVertical()
    {
        Vector3 pos = transform.position;
        Camera mainCamera = Camera.main;

        float yMax = mainCamera.orthographicSize;

        if (pos.y < -yMax || pos.y > yMax)
        {
            Destroy(gameObject);
        }
    }
}

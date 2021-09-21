using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2Vertical : MonoBehaviour
{
    public float maxSpeed = 8f;
    float shipBoundaryRadius = 3f;
    public float scrollSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {

    }
    //Keep the ship inside horizontal bounds
    private void EnforceBounds()
    {
        //horizontal bounds
        Vector3 pos = transform.position;
        Camera mainCamera = Camera.main;
        Vector3 cameraPosition = mainCamera.transform.position;

        float xDist = mainCamera.aspect * mainCamera.orthographicSize;
        float xMax = cameraPosition.x + xDist;
        float xMin = cameraPosition.x - xDist;

        if (pos.x - shipBoundaryRadius < xMin || pos.x + shipBoundaryRadius > xMax)
        {
            pos.x = Mathf.Clamp(pos.x, xMin, xMax);
            //moveDirection.x = -moveDirection.x;
        }
        //vertical bounds
        float yMax = mainCamera.orthographicSize;

        if (pos.y - shipBoundaryRadius < -yMax || pos.y + shipBoundaryRadius > yMax)
        {
            pos.y = Mathf.Clamp(pos.y, -yMax, yMax);
        }

        transform.position = pos;
    }

    void Update()
    {
        //Move the ship
        Vector3 pos = transform.position;
        pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
        pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;
        //Move along the screen scrolling
        if (Camera.main.GetComponent<ScrollingVerticalHandler>().scrolling)
            pos.y += scrollSpeed * Time.deltaTime;

        transform.position = pos;
        //Keep the ship inbound
        EnforceBounds();
    }
}

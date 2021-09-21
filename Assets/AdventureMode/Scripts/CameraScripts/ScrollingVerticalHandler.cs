using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingVerticalHandler : MonoBehaviour
{
    public bool scrolling = true;
    public float speed = 4f;

    void Update()
    {
        if (scrolling)
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Finish")
        {
            transform.Translate(new Vector3(0, 0, 0));
            scrolling = false;
        }
    }
}

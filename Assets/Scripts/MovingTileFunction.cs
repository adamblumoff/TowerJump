using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingTileFunction : MonoBehaviour
{
    public GameObject LeftEndpoint;
    public GameObject RightEndpoint;

    private Transform currentPoint;
    private Rigidbody2D rb;
    public float speed;
    private bool right = true;
    // Start is called before the first frame update
    void Start()
    {
        currentPoint = RightEndpoint.transform;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, currentPoint.position);

        if (currentPoint == RightEndpoint.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
            rb.velocity = new Vector2(-speed, 0);

        if (distance < .5f && currentPoint == RightEndpoint.transform && right)
        {
            right = false;
            Debug.Log("Endpoint reached");
            currentPoint = LeftEndpoint.transform;
            rb.velocity = new Vector2(-speed, 0);
            Debug.Log("turned around" + rb.velocity + " endpoint is" + currentPoint);
        }
        if (distance < .5f && currentPoint == LeftEndpoint.transform && !right)
        {
            right = true;
            currentPoint = RightEndpoint.transform;
            rb.velocity = new Vector2(speed, 0);
        }
    }
}

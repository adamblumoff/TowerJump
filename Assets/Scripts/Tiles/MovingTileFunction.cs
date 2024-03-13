using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTileFunction : MonoBehaviour
{
    public GameObject LeftEndpoint;
    public GameObject RightEndpoint;
    public GameObject player; // Assign this via the Inspector or dynamically

    private Transform currentPoint;
    private Rigidbody2D rb;
    private Vector2 lastPosition;
    public float speed = 5;
    private bool isPlayerOnPlatform = false;
    private bool right = true;

    void Start()
    {
        currentPoint = RightEndpoint.transform;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        lastPosition = rb.position;
    }

    void Update()
    {
        Vector2 currentPosition = rb.position;
        Vector2 deltaPosition = currentPosition - lastPosition;

        if (isPlayerOnPlatform)
        {
            // Apply the platform's movement delta to the player
            player.transform.position += new Vector3(deltaPosition.x, deltaPosition.y, 0);
            
            Debug.Log("position changed" + player.transform.position + " " + rb.transform.position);
        }
        lastPosition = currentPosition;
    }
    void FixedUpdate()
    {
       

        // Existing logic to change direction at endpoints
        float distance = Vector2.Distance(transform.position, currentPoint.position);
        if (distance < .5f)
        {
            if (currentPoint == RightEndpoint.transform && right)
            {
                SwitchDirection(ref right, LeftEndpoint.transform, -speed);
            }
            else if (currentPoint == LeftEndpoint.transform && !right)
            {
                SwitchDirection(ref right, RightEndpoint.transform, speed);
            }
        }
    }

    void SwitchDirection(ref bool direction, Transform newTarget, float newSpeed)
    {
        direction = !direction;
        currentPoint = newTarget;
        rb.velocity = new Vector2(newSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("trigger");
            isPlayerOnPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            isPlayerOnPlatform = false;
        }
    }
}

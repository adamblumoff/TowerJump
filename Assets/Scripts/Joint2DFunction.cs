using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Joint2DFunction : MonoBehaviour
{
    public Joint2D joint;
    private Rigidbody2D tileBody;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "movingTile")
        {
            tileBody = collision.gameObject.GetComponentInChildren<Rigidbody2D>();
            joint.connectedBody = tileBody;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            joint.connectedBody = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttach : MonoBehaviour
{
    public GameObject Player;
    public Animator MegamanAnimator;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "movingTile" && MegamanAnimator.GetBool("Isidle"))
        {
            Player.transform.parent = other.gameObject.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Player.transform.parent = null;
    }
}

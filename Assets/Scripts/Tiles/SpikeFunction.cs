using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFunction : MonoBehaviour
{

    private int damage = 100;


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Collision Detected");
        if (hitInfo.gameObject.CompareTag("Player"))
        {
           CharacterController2D player = hitInfo.GetComponent<CharacterController2D>();
           player.TakeDamage(damage);
        }
    }

}

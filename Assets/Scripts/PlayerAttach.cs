using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerAttach : MonoBehaviour
{
    public GameObject Player;
    public string scene;
    public TilemapCollider2D tilemapCollider;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("scene loading");

            LoadSpecificScene(scene);
        }
    }
   

    public void LoadSpecificScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}

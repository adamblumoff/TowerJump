using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
	public int damage;
	public Rigidbody2D rb;
	private float timer;

	// Use this for initialization
	void Start () 
	{
		rb.velocity = transform.right * speed;
	}

	void Update()
	{
		timer += Time.deltaTime;
		if(timer>2)
		{
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		if(hitInfo.gameObject.CompareTag("Player"))
		{
			CharacterController2D player = hitInfo.GetComponent<CharacterController2D>();
			player.TakeDamage(damage);
			Destroy(gameObject);
		}

	}
    
}

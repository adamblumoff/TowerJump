using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
	public GameObject LeftEndpoint;
	public GameObject RightEndpoint;
	public float health;
	public float speed;

	private Rigidbody2D rb;
	private Animator enemyAnimator;
	private Transform currentPoint;
	private bool dead = false;
	private Vector2 stop = new Vector2(0,0);
	private bool right = true;
	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		enemyAnimator = GetComponent<Animator>();
		currentPoint = RightEndpoint.transform;
		enemyAnimator.SetBool("isRunning", true);
	}
	void Update()
	{
		float distance = Vector2.Distance(transform.position, currentPoint.position);
		if(currentPoint == RightEndpoint.transform)
		{
			rb.velocity = new Vector2(speed, 0);
		} 
		else
			rb.velocity = new Vector2(-speed, 0);
		
		if(distance<.5f && currentPoint == RightEndpoint.transform && right)
		{
			right = false;
			flip();
			StartCoroutine(StopAndShootLeft());
		}
		if(distance<.5f && currentPoint == LeftEndpoint.transform && !right)
		{
			right = true;
			flip();
			StartCoroutine(StopAndShootRight());
		}
		if(distance<.5f)
			rb.velocity = stop;
		if(dead)
			DieAnimation();
		
	}
	private void flip()
	{
		transform.Rotate(0f, 180f, 0f);	
	}

	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			dead = true;
		}
	}
	private IEnumerator StopAndShootLeft()
	{
		enemyAnimator.SetBool("isShooting", true);
		enemyAnimator.SetBool("isRunning", false);
		yield return new WaitForSeconds(2f);
		enemyAnimator.SetBool("isShooting", false);
		enemyAnimator.SetBool("isRunning", true);
		currentPoint = LeftEndpoint.transform;
		rb.velocity = new Vector2(-speed, 0);

	}
	private IEnumerator StopAndShootRight()
	{
		enemyAnimator.SetBool("isShooting", true);
		enemyAnimator.SetBool("isRunning", false);
		yield return new WaitForSeconds(2f);
		enemyAnimator.SetBool("isShooting", false);
		enemyAnimator.SetBool("isRunning", true);
		currentPoint = RightEndpoint.transform;
		rb.velocity = new Vector2(speed, 0);

	}


	private void DieAnimation()
	{
		rb.velocity = stop;
		enemyAnimator.SetBool("isDead", true);
	}
	void Die()
	{
		Destroy(gameObject);
	}

}

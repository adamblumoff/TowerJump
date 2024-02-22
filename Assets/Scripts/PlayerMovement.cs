using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool shooting = false;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		JumpingAnimation();
		ShootingAnimation();
		
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, shooting);
		jump = false;
		shooting = false;
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}
	private void JumpingAnimation()
	{
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}
		else if (Input.GetButtonUp("Jump"))
		{
			jump = false;
			animator.SetBool("IsJumping", false);
		}
		
	}
	private void ShootingAnimation()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			shooting = true;
			animator.SetBool("isShooting", true);
		}
		else if(Input.GetButtonUp("Fire1"))
		{
			shooting = false;
			animator.SetBool("isShooting", false);
		}
	}
}

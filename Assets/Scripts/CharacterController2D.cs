using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float JumpForce = 300f;							// Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform CeilingCheck;							// A position marking where to check for ceilings
	public float health = 100f;

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D Rigidbody2D;
	private bool FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 velocity = Vector3.zero;
	private Animator playerAnimiator;
	private bool dead = false;


	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }


	void Awake()
	{
		Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		playerAnimiator = GetComponent<Animator>();
	}

	void Update()
	{
		bool wasGrounded = Grounded;
		Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, k_GroundedRadius, WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
		
		if(dead){
			DieAnimation();
			dead = false;
		}
	}


	public void Move(float move, bool jump, bool shooting)
	{

		//only control the player if grounded or airControl is turned on
		if (Grounded || AirControl)
		{

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			Rigidbody2D.velocity = Vector3.SmoothDamp(Rigidbody2D.velocity, targetVelocity, ref velocity, MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (Grounded && jump)
		{
			// Add a vertical force to the player.
			Grounded = false;
			Rigidbody2D.AddForce(new Vector2(0f, JumpForce));
		}
		
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		FacingRight = !FacingRight;

		transform.Rotate(0f,180f,0f);
	}
	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			dead = true;
		}
	}
	private void DieAnimation()
	{
		playerAnimiator.SetBool("isDead", true);
	}

	public void MegamanDie()
	{
		string currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(currentSceneName);
	}
}

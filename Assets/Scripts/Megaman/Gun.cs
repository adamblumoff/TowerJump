using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Gun : MonoBehaviour
{
    public Transform bulletSpawner;
	public GameObject bulletPrefab;
	public Animator animator;

	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") )
		{
			Shoot();
		}
	}

	void Shoot ()
	{
		if(!animator.GetBool("isDead"))
			Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
	}
}
   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform bulletSpawner;
	public GameObject bulletPrefab;
    public Animator enemyAnimator;
    
    private int count;
	
	// Update is called once per frame
	void Update () {
		if (enemyAnimator.GetBool("isShooting") == true)
        {
            if (count == 30){
                Shoot();
                count = 0;
            }
            else
                count++;

        }
	}

	void Shoot ()
	{
		Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
	}
}

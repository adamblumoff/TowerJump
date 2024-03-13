using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform bulletSpawner;
	public GameObject bulletPrefab;
    public Animator enemyAnimator;
    public float invertedBulletRate;
    
    private int count;
	
	// Update is called once per frame
	void Update () {
		if (enemyAnimator.GetBool("isShooting") == true)
        {
            if (count == invertedBulletRate){
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

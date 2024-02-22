using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bullet : MonoBehaviour
{
    public GameObject myBullet;
    public Animator bulletAnimator;
    public float myBulletSpeed = 100f;

    public Transform myBulletSpawner;

    public float bulletTimer = 3;

    
    void Update()
    {
        shootBullet();
    }
    private void shootBullet()
    {
        bulletTimer-=Time.deltaTime;
        GameObject myBulletPrefabClone = GetComponent<GameObject>();
        if(Input.GetButtonDown("Fire1"))
        {
            bulletAnimator.SetTrigger("Bullet");
            myBulletPrefabClone = Instantiate(myBullet, transform.position, Quaternion.identity);
            Rigidbody2D myBulletPrefabRigidBody = myBulletPrefabClone.GetComponent<Rigidbody2D>();
            myBulletPrefabRigidBody.AddForce(Vector3.forward*myBulletSpeed, ForceMode2D.Impulse);
            
        }
        if(bulletTimer<=0)
            Destroy(myBulletPrefabClone);
    }
}

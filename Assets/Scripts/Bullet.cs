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
        StartCoroutine(shootBullet());
    }
    private IEnumerator shootBullet()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            bulletAnimator.SetTrigger("Bullet");
            GameObject myBulletPrefabClone = Instantiate(myBullet, transform.position, Quaternion.identity);
            Rigidbody2D myBulletPrefabRigidBody = myBulletPrefabClone.GetComponent<Rigidbody2D>();
            myBulletPrefabRigidBody.AddForce(Vector3.forward*myBulletSpeed, ForceMode2D.Impulse);
            Destroy(myBulletPrefabClone);
            yield return new WaitForSeconds(2);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sourceJump;
    public AudioClip clipJump;

    public AudioSource sourceShoot;
    public AudioClip clipShoot;
    public AudioSource sourceDie;
    public AudioClip clipDie;
    public Animator animator;

    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            sourceJump.PlayOneShot(clipJump);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            sourceShoot.PlayOneShot(clipShoot);
        }
        if(animator.GetBool("isDead"))
        {
            sourceDie.PlayOneShot(clipDie);
        }

    }
}

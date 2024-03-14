using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    
 
    public AudioClip clipShoot;
    public AudioClip clipDie;
    public List<AudioClip> soundList;
    public Animator animator;

    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            AudioClip clipJump = getRandomAudioClip();
            audioSource.PlayOneShot(clipJump);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            audioSource.PlayOneShot(clipShoot);
        }
        if (animator.GetBool("isDead") )
        {
            audioSource.PlayOneShot(clipDie);
        }
    }

    AudioClip getRandomAudioClip()
    {
        int clipIndex = Random.Range(0, soundList.Count-1);
        return soundList[clipIndex];
    }
}

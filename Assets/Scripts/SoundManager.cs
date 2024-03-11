using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    
 
    public AudioClip clipShoot; 
    public List<AudioClip> soundList;

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
    }

    AudioClip getRandomAudioClip()
    {
        int clipIndex = Random.Range(0, soundList.Count-1);
        return soundList[clipIndex];
    }
}

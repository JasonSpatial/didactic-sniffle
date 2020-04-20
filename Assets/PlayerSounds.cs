using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip jumpSound;
    public AudioClip landSound;
    public AudioClip[] stepSounds;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
        _audioSource.clip = jumpSound;
        _audioSource.Play();
    }

    public void PlayLand()
    {
        _audioSource.clip = landSound;
        _audioSource.Play();
    }

}

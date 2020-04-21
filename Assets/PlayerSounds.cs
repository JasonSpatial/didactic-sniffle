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
        Debug.Log($"Playing? {GameManager.Instance.IsPlaying}");
        if (GameManager.Instance.IsPlaying)
        {
            _audioSource.clip = jumpSound;
            _audioSource.Play();
        }
    }

    public void PlayLand()
    {
        Debug.Log($"Playing? {GameManager.Instance.IsPlaying}");
        if (GameManager.Instance.IsPlaying)
        {
            _audioSource.clip = landSound;
            _audioSource.Play();
        }
    }
    
    public void PlayFootstep(bool running)
    {
        Debug.Log($"Playing? {GameManager.Instance.IsPlaying}");
        if (GameManager.Instance.IsPlaying && !_audioSource.isPlaying)
        {
            if (running)
            {
                StartCoroutine(PlayFootstepClip(0.2f));
            }
            else
            {
                StartCoroutine(PlayFootstepClip(0.6f));
                
            }
        }
    }

    IEnumerator PlayFootstepClip(float delayBetweenSteps)
    {
        
        _audioSource.clip = stepSounds[Random.Range(0,stepSounds.Length)];
        _audioSource.Play();
        yield return new WaitForSeconds(delayBetweenSteps);
    }


}

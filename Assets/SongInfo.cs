using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SongInfo : MonoBehaviour
{
    public AudioClip Clip;
    public String SongTitle;
    public String ArtistName;
    private AudioSource _audioSource;
    [SerializeField]
    private TMP_Text _titleText;
    [SerializeField]
    private TMP_Text _artistText;
    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        if (Clip)
        {
            _audioSource.clip = Clip;
            
        }

        if (SongTitle.Length > 0)
        {
            _titleText.text = SongTitle;
        }

        if (ArtistName.Length > 0)
        {
            _artistText.text = ArtistName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

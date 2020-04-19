using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class ChillCharger : MonoBehaviour
{

    private AudioSource _audioSource;
    private float _clipTime = 0;
    private float _remainingChill;
    private bool _isCharging;
    private Light _illuminator;
    private float _chargeFactor;
    private bool _spent = false;
    private Material _emissive;
    private Color _emissiveColor;
    private float _emissionDelta = 1;
    private SphereCollider _chargingCollider;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource.clip)
        {
            _clipTime = _audioSource.clip.length;
        }

        _emissive = GetComponent<Renderer>().materials[0];
        _illuminator = GetComponentInChildren<Light>();
        _chargeFactor = _illuminator.intensity/_clipTime;
        _emissiveColor = _emissive.GetColor("_EmissionColor");
        _chargingCollider = GetComponent<SphereCollider>();
    }

    public float ChargeFactor
    {
        get => _chargeFactor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(("Player")))
        {
            _isCharging = true;
            if (!_audioSource.isPlaying && _clipTime > 0 && !_spent)
            {
                _audioSource.Play();
            }
            
        }

    }

    void Update()
    {
        if (_isCharging)
        {
            if (_audioSource.isPlaying)
            {
                _illuminator.intensity -= (_chargeFactor * Time.deltaTime);
                _emissionDelta -= (_chargeFactor * Time.deltaTime)/2;
                _emissive.SetColor("_EmissionColor", _emissiveColor * _emissionDelta);
                _isCharging = true;
            }
            else
            {
                _spent = true;
                _chargingCollider.radius = 0;
                Invoke("DisableCollider", 1);
            }
        }
    }

    void DisableCollider()
    {
        _chargingCollider.enabled = false;
    }
}

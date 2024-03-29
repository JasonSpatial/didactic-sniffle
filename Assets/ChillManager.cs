﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;

public class ChillManager : MonoBehaviour
{
    
    private float _chargeFactor;
    private bool _charging;
    [SerializeField]
    private float _chargePercentage = 100;

    public Image ChillBar;
    public float _dischargeFactor;
    

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Charger"))
        {
            Debug.Log("Charging");
            GameManager.Instance.HelpStep2();
            _charging = true;
            _chargeFactor = other.gameObject.GetComponent<ChillCharger>().ChargeFactor;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"Leaving trigger: {other.gameObject.tag}");

        if (other.gameObject.CompareTag(("Charger")))
        {
            _charging = false;
            
        }
    }
    
    void Update()
    {
        if (GameManager.Instance.IsPlaying && !GameManager.Instance.IsPaused)
        {
            if (_charging && _chargePercentage < 100)
            {
                _chargePercentage += (_chargeFactor * Time.fixedDeltaTime)/_dischargeFactor;
            }

            if (!_charging && _chargePercentage > 0)
            {
                _chargePercentage -= (_dischargeFactor * Time.fixedDeltaTime);
            }
            ChillBar.fillAmount = _chargePercentage/100;            
        }
    }
}

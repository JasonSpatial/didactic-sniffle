using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    private float _originalY;
    private Vector3 _position;

    public float bobberStrength = 1;
    
    void Start()
    {
        _position = transform.position;
        _originalY = _position.y;
        
    }

    void Update()
    {
        transform.position = new Vector3(_position.x, _originalY + ((float)Math.Sin(Time.time) * bobberStrength), _position.z);
    }
}

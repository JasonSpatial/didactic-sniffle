using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    private float _originalY;
    private Vector3 _position;
    private Canvas _canvas;

    public float bobberStrength = 1;
    public float RotationsPerMinute = 6;
    void Start()
    {
        _position = transform.position;
        _originalY = _position.y;
        _canvas = gameObject.GetComponent<Canvas>();

    }

    void Update()
    {
        transform.Rotate(0f,(float)(6.0*RotationsPerMinute*Time.deltaTime),0f);
        transform.position = new Vector3(_position.x, _originalY + ((float)Math.Sin(Time.time) * bobberStrength), _position.z);
    }
}

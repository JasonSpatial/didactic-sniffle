using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSaver : MonoBehaviour
{
    public GameObject fallSpawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(("Fall Saver")))
        {
            gameObject.transform.position = fallSpawn.transform.position;
        }
    }
}

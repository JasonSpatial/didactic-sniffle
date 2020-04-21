using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLabelManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button resumeButton;

    private void Start()
    {
        startButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }

    private void Update(){
        
        if (GameManager.Instance != null && enabled)
        {
            if (!GameManager.Instance.IsPlaying)
            {
                startButton.gameObject.SetActive(true);
                resumeButton.gameObject.SetActive(false);
            }
            if (GameManager.Instance.IsPlaying && GameManager.Instance.IsPaused)
            {
                startButton.gameObject.SetActive(false);
                resumeButton.gameObject.SetActive(true);
            }
            
        }
    }

}

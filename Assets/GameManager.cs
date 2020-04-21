using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Net.Configuration;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    
    public bool bypassHelp;

    private bool _helpStep1Shown = false;
    private bool _helpstep2Shown = false;
    
    private bool _isPaused;
    public bool IsPaused => _isPaused;

    private bool _isPlaying;
    public bool IsPlaying => _isPlaying;

    
    public RigidbodyFirstPersonController player;
    
    public SetGameCamera setGameCamera;
    public Canvas gameUI;
    public Canvas helpStep1;
    public Canvas helpStep2;
    public Canvas helpStep3;
    public Canvas menu;
    
    public void HelpStep1()
    {
        _isPaused = true;
        player.mouseLook.lockCursor = false;
        helpStep1.gameObject.SetActive(true);
    }

    public void HelpStep2()
    {
        if (!_helpstep2Shown)
        {
            _isPaused = true;
            Cursor.visible = true;
            player.mouseLook.lockCursor = false;
            helpStep2.gameObject.SetActive(true);
            _helpstep2Shown = true;
        }
    }

    public void HelpStep3()
    {
        
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
        _isPaused = false;
        _isPlaying = false;
    }

    void Start()
    {
        // Cursor.visible = true;
        gameUI.enabled = false;
        helpStep1.gameObject.SetActive(false);
        helpStep2.gameObject.SetActive(false);
        // helpStep3.enabled = false;
        menu.gameObject.SetActive(true);
        setGameCamera.EnableCartCamera();

    }

    public void PauseGame()
    {
        player.mouseLook.lockCursor = false;
        menu.gameObject.SetActive(true);
        _isPaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("resuming");
        player.mouseLook.lockCursor = true;
        helpStep1.gameObject.SetActive(false);
        helpStep2.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        _isPaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        player.mouseLook.lockCursor = true;
        menu.gameObject.SetActive(false);
        gameUI.enabled = true;
        _isPlaying = true;
        setGameCamera.EnableGameCamera();
        
        HelpStep1();

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (IsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
            
        }
    }
}

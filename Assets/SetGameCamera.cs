using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SetGameCamera : MonoBehaviour
{
    public CinemachineExternalCamera gameCamera;

    public CinemachineVirtualCamera dollyCamera;

    public Camera mainCamera;

    public void EnableGameCamera()
    {
        dollyCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
    }
    
    public void EnableCartCamera()
    {
        // mainCamera.gameObject.SetActive(true);
        dollyCamera.gameObject.SetActive(true);
        gameCamera.gameObject.SetActive(false);
    }
}

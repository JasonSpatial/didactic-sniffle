using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SetGameCamera : MonoBehaviour
{
    public CinemachineExternalCamera gameCamera;

    public CinemachineVirtualCamera dollyCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            dollyCamera.gameObject.SetActive(false);
            gameCamera.gameObject.SetActive(true);
        }
    }
}

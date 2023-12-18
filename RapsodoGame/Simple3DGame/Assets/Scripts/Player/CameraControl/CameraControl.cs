using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject thirdCam;
    public GameObject firstCam;
    
    public int camMode;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(SwitchCamera());
            if (camMode == 0)
            {
                camMode = 1;
            }
            else
            {
                camMode = 0;
            }
            
        }
    }

    IEnumerator SwitchCamera()
    {
        yield return new WaitForSeconds(.01f);
        if (camMode == 0)
        {
            thirdCam.SetActive(true);
            firstCam.SetActive(false);
            
        }
        if(camMode == 1)
        {
            thirdCam.SetActive(false);
            firstCam.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Teleport_enemy : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] virtualCameras;
    private int currentCameraindex;

    private void OnTriggerEnter2D(Collider2D coll)
    { 
        if (coll.gameObject.tag =="Enemy")
        {
            Destroy(coll.gameObject);
            SwitchCamera();
        }

    }

    private void SwitchCamera()
    {   

        virtualCameras[currentCameraindex].gameObject.SetActive(false);
        currentCameraindex++;

        if (currentCameraindex >= virtualCameras.Length)
            currentCameraindex = 0; 
        virtualCameras[currentCameraindex].gameObject.SetActive(true);

    }
}

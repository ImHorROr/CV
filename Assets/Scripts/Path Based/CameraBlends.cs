using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraBlends : MonoBehaviour
{
    CinemachineVirtualCamera mainCam;
    [SerializeField] CinemachineVirtualCamera camtoSwitchTO;
    EnemyLockOn lockOn;
    private void Awake()
    {
        lockOn = GetComponent<EnemyLockOn>();
    }
    void Start()
    {
        lockOn.FoundTarget += CamFocus;
        lockOn.LostTarget += unFocus;
        mainCam = GameObject.FindWithTag("VcamMain").GetComponent<CinemachineVirtualCamera>();
    }
    private void CamFocus()
    {
        mainCam.Priority = 0;
        camtoSwitchTO.Priority = 20;
    }
    public void unFocus()
    {
        mainCam.Priority = 20;
        camtoSwitchTO.Priority = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

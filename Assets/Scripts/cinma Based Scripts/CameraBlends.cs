using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBlends : MonoBehaviour
{
    CinemachineVirtualCamera mainCam;
    CinemachineBrain brain;
    [SerializeField] CinemachineVirtualCamera camtoSwitchTO;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindWithTag("Player").GetComponent<CinemachineVirtualCamera>();
    }
    private void OnTriggerEnter(Collider other)
    {
        mainCam.Priority = 0;
        camtoSwitchTO.Priority = 20;
    }
    private void OnTriggerExit(Collider other)
    {
        mainCam.Priority = 0;
        camtoSwitchTO.Priority = 20;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

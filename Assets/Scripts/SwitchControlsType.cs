using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchControlsType : MonoBehaviour
{
    [SerializeField] CinemachineInputProvider mouseInputProvider;
    [SerializeField] CinemachineInputProvider touchInputProvider;
    [SerializeField] CinemachineVirtualCamera cinvrcamera;
    CinemachinePOV camera;
    MyPlayerInput myPlayerInput;
    private void Start()
    {
        touchInputProvider.enabled = false;
        mouseInputProvider.enabled = true;
        camera = cinvrcamera.GetCinemachineComponent<CinemachinePOV>();
    }
    private void Update()
    {
        if (myPlayerInput == null) return;
        if (myPlayerInput.MovmentTouch.enabled)
        {
           // Vector2 delta = myPlayerInput.MovmentTouch.Look.ReadValue<Vector2>();
           // camera.m_VerticalAxis.Value += delta.y * 200 * Time.deltaTime;
        //    camera.m_HorizontalAxis.Value += delta.x * 200 * Time.deltaTime;
        }

    }
    public void Switch(MyPlayerInput myPlayerInput)
    {
        this.myPlayerInput = myPlayerInput;
        if (myPlayerInput.Movment.enabled)
        {
            myPlayerInput.Movment.Disable();
            myPlayerInput.MovmentTouch.Enable();
            touchInputProvider.enabled = true;
            mouseInputProvider.enabled = false;
        }
        else if(myPlayerInput.MovmentTouch.enabled)
        {
            myPlayerInput.MovmentTouch.Disable();
            myPlayerInput.Movment.Enable();
            touchInputProvider.enabled = false;
            mouseInputProvider.enabled = true;

        }
    }
}
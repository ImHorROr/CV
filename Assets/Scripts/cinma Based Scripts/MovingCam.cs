using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class MovingCam : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] float camSpeed = 1;
    CinemachineTrackedDolly dolly;
    MyPlayerInput myPlayerInput;
    SwitchControlsType switchControls;
    // Start is called before the first frame update
    private void Awake()
    {
        myPlayerInput = new MyPlayerInput();
        myPlayerInput.Movment.Enable();

    }
    void Start()
    {
        dolly = cam.GetCinemachineComponent<CinemachineTrackedDolly>();
        switchControls = GetComponent<SwitchControlsType>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myPlayerInput.Movment.enabled)
        {
            MovmentWithKeyBoard();

        }
        if (myPlayerInput.MovmentTouch.enabled)
        {
            MovmentWithTouch();

        }

    }
    private void MovmentWithKeyBoard()
    {
        if (myPlayerInput.Movment.MoveForward.IsPressed())
        {
            dolly.m_PathPosition = Mathf.Clamp01(dolly.m_PathPosition + camSpeed * Time.deltaTime);
        }


        if (myPlayerInput.Movment.MoveBackward.IsPressed())
        {

            dolly.m_PathPosition = Mathf.Clamp01(dolly.m_PathPosition - camSpeed * Time.deltaTime);
        }
    }
    private void MovmentWithTouch()
    {
        if (myPlayerInput.MovmentTouch.MoveForward.IsPressed())
        {
            Vector2 lmao = myPlayerInput.MovmentTouch.MoveForward.ReadValue<Vector2>();
            if(lmao.y >0.1)
            {
                dolly.m_PathPosition = Mathf.Clamp01(dolly.m_PathPosition + camSpeed * Time.deltaTime);
            }
            else if(lmao.y < -0.2f)
            {
                dolly.m_PathPosition = Mathf.Clamp01(dolly.m_PathPosition - camSpeed * Time.deltaTime);

            }
        }
    }

    public void Switch()
    {
        switchControls.Switch(myPlayerInput);
    }
    public void Telepoert(float pos)
    {
        dolly.m_PathPosition = pos;
    }
}

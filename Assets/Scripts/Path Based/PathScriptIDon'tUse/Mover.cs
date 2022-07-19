using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PathCreation;
public class Mover : MonoBehaviour
{
    MyPlayerInput myPlayerInput;
    SwitchControlsType switchControls;
    [SerializeField]FollowPath patrolPath2;
    [SerializeField]float Speed = 100;
    private void Awake()
    {
        myPlayerInput = new MyPlayerInput();
        myPlayerInput.Movment.Enable();

        //myPlayerInput.Movment.MoveBackward.performed += decCurrent;
        //myPlayerInput.Movment.MoveForward.performed += incCurrent;
    }

    //private void incCurrent(InputAction.CallbackContext obj)
    //{
    //    throw new NotImplementedException();
    //}

    //private void decCurrent(InputAction.CallbackContext obj)
    //{
    //    throw new NotImplementedException();
    //}

    void Start()
    {
        switchControls = GetComponent<SwitchControlsType>();
    }

    void Update()
    {
        if (myPlayerInput.Movment.enabled)
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
            Forward();
        }

        if (myPlayerInput.Movment.MoveBackward.IsPressed())
        {
            BackWard();
        }
    }
    private void MovmentWithTouch()
    {
        if (myPlayerInput.MovmentTouch.MoveForward.IsPressed())
        {
            Vector2 stick = myPlayerInput.MovmentTouch.MoveForward.ReadValue<Vector2>();
            if (stick.y > 0.2)
            {
                Forward();
            }
            else if (stick.y < -0.2f)
            {
                BackWard();
            }
        }
    }
    void Forward()
    {
        //Vector3 pos = Vector3.MoveTowards(transform.position, patrolPath2.GetCurrentWaypoint(), Speed * Time.deltaTime);
        //rigidbody.MovePosition(pos);
        //if(patrolPath2.AtWaypoint())
        //{
        //    patrolPath2.AddWaypoint();
        //}
    }
    void BackWard()
    {
        //Vector3 pos = Vector3.MoveTowards(transform.position, patrolPath2.GetLastWaypoint(), Speed * Time.deltaTime);
        //rigidbody.MovePosition(pos);
        //if (patrolPath2.AtWaypointReverse())
        //{
        //        patrolPath2.RemoveWaypoint();
        //}

    }
    public void Switch()
    {
        switchControls.Switch(myPlayerInput);
    }

    public void Teleport(int selected)
    {
        print(selected);
        //current = selected;
      //  transform.position = Points[selected].position;
    }
}

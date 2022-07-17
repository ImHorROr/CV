using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PathCreation;
using PathCreation.Examples;
public class Follower : MonoBehaviour
{
    [SerializeField] float Speed = 100;
    [SerializeField] PathCreator path;

    [SerializeField]GeneratePathExample generatePath;

    MyPlayerInput myPlayerInput;
    SwitchControlsType switchControls;
    EnemyLockOn lockOn;

    [SerializeField]float dist;


    private void Awake()
    {
        myPlayerInput = new MyPlayerInput();
        myPlayerInput.Movment.Enable();
    }

    void Start()
    {
        switchControls = GetComponent<SwitchControlsType>();
        transform.position = generatePath.waypoints[0].position;
        lockOn = GetComponent<EnemyLockOn>();
    }

    // Update is called once per frame
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
        dist += Speed * Time.deltaTime;
        transform.position = path.path.GetPointAtDistance(dist);
        //transform.rotation = path.path.GetRotationAtDistance(dist);
    }
    void BackWard()
    {
        dist -= Speed * Time.deltaTime;
        transform.position = path.path.GetPointAtDistance(dist);
        //transform.rotation = path.path.GetRotationAtDistance(dist);
    }
    public void Switch()
    {
        switchControls.Switch(myPlayerInput);
    }

    public void Teleport(int selected)
    {
        transform.position = generatePath.waypoints[selected].position;     
    }
    public void EditDistance(int distance)
    {
        lockOn.ResetTarget();
        dist = distance;
    }
}
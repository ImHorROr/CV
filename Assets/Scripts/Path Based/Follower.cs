using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PathCreation;
using PathCreation.Examples;
using UnityEngine.SceneManagement;

public class Follower : MonoBehaviour
{
    [SerializeField] float Speed = 100;
    [SerializeField] PathCreator path;

    [SerializeField] GeneratePathExample generatePath;

    public MyPlayerInput myPlayerInput { get; set; }
    SwitchControlsType switchControls;
    EnemyLockOn lockOn;
    [SerializeField]float dist;
    Vector3 pos;
    private int health = 6;
    [SerializeField] GameObject gameoverPanle;

    public void Awake()
    {
        myPlayerInput = new MyPlayerInput();
        myPlayerInput.MovmentCont.Enable();
        
    }

     void Start()
    {
        if(gameoverPanle != null)
        {

        gameoverPanle.SetActive(false);
        }
        switchControls = GetComponent<SwitchControlsType>();
        if(generatePath == null)
        {
            generatePath = FindObjectOfType<GeneratePathExample>();
        }
        if(path == null)
        {
            path = FindObjectOfType<PathCreator>();
        }
        transform.position = generatePath.waypoints[0].position;
        EditDistance();
        lockOn = GetComponent<EnemyLockOn>();
        myPlayerInput.MovmentCont.reset.performed += Reset;


    }
    private void Reset(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    // Update is called once per frame
    void Update()
    {

        if (myPlayerInput == null)
        {
            myPlayerInput = new MyPlayerInput();
            myPlayerInput.MovmentCont.Enable();

        }
        if (myPlayerInput.Movment.enabled)
        {
            MovmentWithKeyBoard();
        }
        if (myPlayerInput.MovmentTouch.enabled)
        {
            MovmentWithTouch();
        }
        if (myPlayerInput.MovmentCont.enabled)
        {
            MovmentWithKeyBoard();

        }
    }
    private void MovmentWithKeyBoard()
    {
        if (myPlayerInput.Movment.MoveForward.IsPressed() || myPlayerInput.MovmentCont.test.IsPressed())
        {
            Forward();
        }

        if (myPlayerInput.Movment.MoveBackward.IsPressed() || myPlayerInput.MovmentCont.test1.IsPressed())
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

    public int GetHealth()
    {
        return health;
    }

    void Forward()
    {
        dist += Speed * Time.deltaTime;
        transform.position = path.path.GetPointAtDistance(dist);

    }


    void BackWard()
    {
        dist -= Speed * Time.deltaTime;
        transform.position = path.path.GetPointAtDistance(dist);
    }
    public void Switch()
    {
        switchControls.Switch(myPlayerInput);
    }

    public void dealDamage(int v)
    {
        health -= v;
        print(health);
        if(health <= 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        gameoverPanle.SetActive(true);
    }

    public void Teleport(int selected)
    {
        transform.position = generatePath.projectWaypoints[selected].position;
        EditDistance();
    }
    public void EditDistance()
    {
        lockOn?.ResetTarget();
        dist = path.path.GetClosestDistanceAlongPath(transform.position);
        pos = path.path.GetPointAtDistance(dist);
    }
    
}

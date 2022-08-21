using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.DualShock;

public class testCont : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public MyPlayerInput myPlayerInput;

    public void Awake()
    {
        myPlayerInput = new MyPlayerInput();
        myPlayerInput.MovmentCont.Enable();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        text.text = myPlayerInput.MovmentCont.test.IsPressed().ToString();
    }
}

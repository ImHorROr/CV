using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject desktop;
    [SerializeField] GameObject mobile;
    Vector2 res;

    // Start is called before the first frame update

    void Start()
    {
        mobile.SetActive(false);
        desktop.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        print(res.x +" -- "+ res.y);
        if(Input.GetKeyDown(KeyCode.S))
        {
            res = new Vector2(Screen.width, Screen.height);

            Cheack();
        }
    }

    private void Cheack()
    {
        if (res.x <= 960 && res.y <= 600)
        {
            mobile.SetActive(true);
            desktop.SetActive(false);
        }
        else
        {
            mobile.SetActive(false);
            desktop.SetActive(true);
        }
    }
}

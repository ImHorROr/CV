using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject gameoverPanel;
    float time;

    // Start is called before the first frame update

    void Start()
    {
        gameoverPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(time > 5)
        {
            gameoverPanel.SetActive(true);

        }
    }

   
}

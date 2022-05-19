using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print(other);
    }
    private void OnTriggerExit(Collider other)
    {
        
        print(other);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

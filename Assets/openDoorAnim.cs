using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoorAnim : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Animator>().SetTrigger("open");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

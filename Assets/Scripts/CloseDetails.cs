using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloseDetails : MonoBehaviour
{
    public void CloseDetail()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
        gameObject.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

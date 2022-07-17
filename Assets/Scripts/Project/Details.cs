using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Details : MonoBehaviour
{
    public string currentProjectURL { get; set; }
    public void CloseDetail()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
        gameObject.SetActive(false);
        currentProjectURL = string.Empty;
    }
    public void OpenLink()
    {
        Application.OpenURL(currentProjectURL);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

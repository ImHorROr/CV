using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Video;

public class ShowProject : MonoBehaviour
{
    [SerializeField] Project project;
    int currentImage, maxImage;
    RawImage rawImage;
    VideoPlayer videoPlayer;
    [SerializeField] Transform DetailsPanel;
    [SerializeField] Transform WierdEffects;

    Details details;
    MyPlayerInput myPlayerInput;
    Follower follower;

    EnemyLockOn lockOn;
    private float currntTime = Mathf.Infinity;
    private int cooldown = 5;
    private void Awake()
    {
        lockOn = FindObjectOfType<EnemyLockOn>();
        details = FindObjectOfType<Details>();
    }

    private void Close(InputAction.CallbackContext obj)
    {
        print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        CloseDetails();
    }

    // Start is called before the first frame update
    void Start()
    {
        follower = FindObjectOfType<Follower>();
        this.myPlayerInput = follower.myPlayerInput;
        myPlayerInput.MovmentCont.CloseDetails.performed += Close;

        if (DetailsPanel.gameObject.activeInHierarchy)
        {
            DetailsPanel.gameObject.SetActive(false);
        }
        //for later
       // lockOn.LostTarget += CloseDetails;

        if (project.videoPlayer != null)
        {
            videoPlayer = Instantiate(project.videoPlayer, this.transform);
        }

        rawImage = GetComponentInChildren<RawImage>();
        rawImage.texture = project.images[0];


        currentImage = 0;
        maxImage = project.images.Length -1 ;
    }
    private void Update()
    {
        if(myPlayerInput == null)
        {
            myPlayerInput = follower.myPlayerInput;
        }
    }
    public void ShowDetalis()
    {
        DetailsPanel.gameObject.SetActive(true);
        details.currentProjectURL = project.link;
        details.desc.GetComponent<TextMeshProUGUI>().text = project.desc;
        details.title.GetComponent<TextMeshProUGUI>().text = project.title;
       // DetailsPanel.GetComponentInChildren<TextMeshProUGUI>().text = project.desc;
    }
    public void CloseDetails()
    {
        //DetailsPanel.GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
        details.desc.GetComponent<TextMeshProUGUI>().text = string.Empty;
        details.title.GetComponent<TextMeshProUGUI>().text = string.Empty;
        details.currentProjectURL = string.Empty;
        DetailsPanel.gameObject.SetActive(false);
        WierdEffects.gameObject.SetActive(false);
        //remove this later it was cusaing an infinte loop with lockon and the events in line 50
        lockOn.ResetTarget();
    }
    public void NextPhoto()
    {
        currentImage++;


        if (currentImage > maxImage)
        {
            currentImage = 0;
        }   
        rawImage.texture = project.images[currentImage];

        if (rawImage.texture.name == "Vid")
        {
            videoPlayer.Play();
        }
        else
        {
            //videoPlayer.Stop();

        }

    }
}

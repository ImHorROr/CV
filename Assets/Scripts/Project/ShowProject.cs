using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    EnemyLockOn lockOn;
    private void Awake()
    {
        lockOn = FindObjectOfType<EnemyLockOn>();
        details = FindObjectOfType<Details>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(DetailsPanel.gameObject.activeInHierarchy)
        {
            DetailsPanel.gameObject.SetActive(false);
        }

        lockOn.LostTarget += CloseDetails;

        if (project.videoPlayer != null)
        {
            videoPlayer = Instantiate(project.videoPlayer, this.transform);
        }

        rawImage = GetComponentInChildren<RawImage>();
        rawImage.texture = project.images[0];


        currentImage = 0;
        maxImage = project.images.Length -1 ;
    }
    public void ShowDetalis()
    {
        DetailsPanel.gameObject.SetActive(true);
        details.currentProjectURL = project.link;
        DetailsPanel.GetComponentInChildren<TextMeshProUGUI>().text = project.desc;
    }
    public void CloseDetails()
    {
        DetailsPanel.GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
        details.currentProjectURL = string.Empty;
        DetailsPanel.gameObject.SetActive(false);
        WierdEffects.gameObject.SetActive(false);
    }
    public void NextPhoto()
    {
        print(1);
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
            videoPlayer.Stop();

        }

    }
}

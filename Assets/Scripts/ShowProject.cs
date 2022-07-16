using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ShowProject : MonoBehaviour
{
    [SerializeField] Project project;
    Image image;
    int currentImage, maxImage;
    RawImage rawImage;
    VideoPlayer video;
    bool currentIsVideo = false;

    //maybe create an array here and match it with the video in images?
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponentInChildren<Image>();
        rawImage = GetComponentInChildren<RawImage>();
        video = GetComponentInChildren<VideoPlayer>();



        rawImage.gameObject.SetActive(false);


        image.sprite = project.images[0];
        currentImage = 0;
        maxImage = project.images.Length;
    }
    void OnMouseEnter()
    {
        
    }
     void OnMouseExit()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextPhoto()
    {
        currentImage++;
        if (currentImage > maxImage)
        {
            currentImage = 0;
            currentIsVideo = true;
            PlayVideo();
        }

        if (currentIsVideo == true) return;

        image.sprite = project.images[currentImage];
    }

    private void StopVideo()
    {
        currentIsVideo = false;
        rawImage.gameObject.SetActive(false);
        video.Stop();
    }

    private void PlayVideo()
    {
        currentIsVideo = true;
        rawImage.gameObject.SetActive(true);
        video.Play();
    }
}

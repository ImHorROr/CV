using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "Project", menuName = "Projects")]
public class Project : ScriptableObject
{
    public Texture[] images;
    public VideoPlayer videoPlayer;
    public string title;
    public string desc;
    public string link;
}

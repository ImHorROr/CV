using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Project", menuName = "Projects")]
public class Project : ScriptableObject
{
    [SerializeField] public Sprite[] images;
    [SerializeField] public string desc;
    [SerializeField] public string link;
}

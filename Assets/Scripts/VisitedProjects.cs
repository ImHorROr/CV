using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VisitedProjects : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI visitedCountText;

    [SerializeField] List<Project> projects = new List<Project>();
    [SerializeField] List<Project> visitedProjectsbyType = new List<Project>();
    [SerializeField] List<int> visitedProjectsCount = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        Invoke("brr", 1f);

    }
    void brr()
    {
        foreach (var project in FindObjectsOfType<ShowProject>())
        {
            if (!projects.Contains(project.getProject()))
            {
                projects.Add(project.getProject());
            }
        }
        visitedCountText.text = $"Visited Projects : {visitedProjectsCount.Count} / {projects.Count}";
    }
    public void VistiedAProject(Project type)
    {
        if (visitedProjectsbyType.Contains(type))
        {
            return;
        }
        visitedProjectsbyType.Add(type);
        visitedProjectsCount.Add(1);
        visitedCountText.text = $"Visited Projects : {visitedProjectsCount.Count} / {projects.Count}";
        //this will be called when you visit a project for each project

    }

    // i have list of all projects
    // cheack when a project is visited
    // call event to increase the number
    // update text

    // Update is called once per frame
    void Update()
    {
        
    }
}

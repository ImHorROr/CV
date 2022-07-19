using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointsTeleporter : MonoBehaviour
{
    [SerializeField] GeneratePathExample generatePath;
    [SerializeField] Transform button;
    [SerializeField] List<Transform> buttons = new List<Transform>();
    [SerializeField] List<float> dist = new List<float>();
    Follower follower;
    // Start is called before the first frame update
    void Start()
    {
        generatePath = FindObjectOfType<GeneratePathExample>();
        follower = FindObjectOfType < Follower>();
        if (generatePath == null) return;


        foreach (var waypoint in generatePath.waypoints)
        {
            dist.Add(waypoint.position.z);

            buttons.Add(Instantiate(button , transform));

        }
        foreach (var b in buttons)
        {
            int i = buttons.IndexOf(b.transform);
            b.GetComponent<Button>().onClick.AddListener(() => info(i));

        }

    }
    void info(int i)
    {
        follower.Teleport(i);
        follower.EditDistance(dist[i]);
    }
}

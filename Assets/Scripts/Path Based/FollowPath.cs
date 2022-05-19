using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField] float waypointTolerance = 1f;
    [SerializeField] int currentWaypointIndex = 0;



    const float waypointGizmoRadius = 0.3f;
    [SerializeField] Transform player;

    private void Update()
    {
        if(currentWaypointIndex <=0)
        {
            currentWaypointIndex = 0;
        }
    }
    private int GetcurrentWaypointIndex()
    {
        return currentWaypointIndex;
    }

    public bool AtWaypoint()
    {
        float distanceToWaypoint = Vector3.Distance(player.transform.position, GetCurrentWaypoint());
        return distanceToWaypoint < waypointTolerance;
    }

    public bool AtWaypointReverse()
    {
        float distanceToWaypoint = Vector3.Distance(player.transform.position, GetLastWaypoint());
        return distanceToWaypoint < waypointTolerance;
    }


    public void AddWaypoint()
    {
        currentWaypointIndex = GetNextIndex(currentWaypointIndex);
    }
    public void RemoveWaypoint()
    {
        currentWaypointIndex = GetNextIndex(currentWaypointIndex - 2);
    }


    public Vector3 GetCurrentWaypoint()
    {
        return GetWaypoint(currentWaypointIndex);
    }
    public Vector3 GetLastWaypoint()
    {
        if (GetcurrentWaypointIndex() <= 0)
        {
            return GetWaypoint(0);
        }
        else
        {
        return GetWaypoint(currentWaypointIndex - 1);

        }
    }

    private int GetNextIndex(int i)
    {
        if (i + 1 == transform.childCount)
        {
            return 0;
        }
        return i + 1;
    }
    private Vector3 GetWaypoint(int i)
    {
        return transform.GetChild(i).position;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        for (int i = 0; i < transform.childCount; i++)
        {
            int j = GetNextIndex(i);
            Gizmos.DrawSphere(GetWaypoint(i), waypointGizmoRadius);

            Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
        }
    }

}

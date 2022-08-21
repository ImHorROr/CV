using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Point : MonoBehaviour
{
    public bool isNearproject;
    [SerializeField] float noticeZone = 10;
    [SerializeField] LayerMask targetLayers;
    GeneratePathExample path;
    string name;
    // Start is called before the first frame update



    void Start()
    {
        path = GetComponentInParent<GeneratePathExample>();
        Collider[] nearbyTargets = Physics.OverlapSphere(transform.position, noticeZone, targetLayers);
        if (nearbyTargets.Length <= 0)
        {
            isNearproject = false;
        }
        else
        {
            isNearproject = true;
            //there is a race condtion with WaypointsTeleporter and the name setting so edit exucsoin order inside the editor
            name = nearbyTargets[0].name;
            
            path.projectWaypoints.Add(transform);
        }

    }
    public string pointName()
    {
        return name.ToString();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, noticeZone);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

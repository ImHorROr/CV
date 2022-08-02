using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public bool isNearproject;
    [SerializeField] float noticeZone = 10;
    [SerializeField] LayerMask targetLayers;
    GeneratePathExample path;

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
            path.projectWaypoints.Add(transform);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, noticeZone);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

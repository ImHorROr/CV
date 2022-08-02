using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public bool isNearproject;
    [SerializeField] float noticeZone = 10;
    [SerializeField] LayerMask targetLayers;

    // Start is called before the first frame update
    void Start()
    {
        Collider[] nearbyTargets = Physics.OverlapSphere(transform.position, noticeZone, targetLayers);
        if (nearbyTargets.Length <= 0)
        {
            isNearproject = false;
        }
        else
        {
            isNearproject = true;
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

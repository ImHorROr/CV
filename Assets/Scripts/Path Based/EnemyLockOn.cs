using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLockOn : MonoBehaviour
{
    [SerializeField]Transform currentTarget;

    [SerializeField] LayerMask targetLayers;
    [SerializeField] Transform enemyTarget_Locator;

    [Header("Settings")]
    [SerializeField] float noticeZone = 10;

    public event Action FoundTarget;
    public event Action LostTarget;

    private void Update()
    {
        ScanNearBy();
    }
    public Transform ScanNearBy()
    {
        //for some reason only capsul is detected
        Collider[] nearbyTargets = Physics.OverlapSphere(transform.position, noticeZone, targetLayers);
        Transform closestTarget = null;
        currentTarget = null;
        if (nearbyTargets.Length <= 0)
        {
            return null; 
        }
        closestTarget = nearbyTargets[0].transform;

        float Dist = Vector3.Distance(nearbyTargets[0].transform.position, transform.position);
        if (Dist > noticeZone)
        {
            ResetTarget();
        }
        else
        {
            currentTarget = closestTarget;
            LookAtTarget();
        }

        return closestTarget;
    }

    public void ResetTarget()
    {
        currentTarget = null;
        if (LostTarget != null)
        {
            LostTarget.Invoke();
        }
    }
    private void LookAtTarget()
    {
        if(FoundTarget != null)
        {
            FoundTarget.Invoke();
        }
        enemyTarget_Locator.transform.position = currentTarget.position;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, noticeZone);   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telpoert : MonoBehaviour
{
    FollowPath follow;
    [SerializeField] int pointToTeleportTo;
    void Start()
    {
        follow = FindObjectOfType<FollowPath>();
    }
    public void Teleport()
    {
        //follow.Teleport(pointToTeleportTo);
    }

}

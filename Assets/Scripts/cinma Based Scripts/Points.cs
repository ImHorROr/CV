using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] int point;
    MovingCam cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<MovingCam>();
    }

    public void Teleport()
    {

        cam.Telepoert(point);
    }
}

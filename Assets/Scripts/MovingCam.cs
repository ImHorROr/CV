using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MovingCam : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] float camSpeed = 5;
    CinemachineTrackedDolly dolly;


    // Start is called before the first frame update
    void Start()
    {
        dolly = cam.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    // Update is called once per frame
    void Update()
    {
        print(dolly.m_Path.PathLength);
        if (Input.GetKey(KeyCode.W))
        {
            dolly.m_PathPosition = Mathf.Clamp(dolly.m_PathPosition + camSpeed * Time.deltaTime, 0, dolly.m_Path.PathLength);
        }
        if (Input.GetKey(KeyCode.S))
        {
            dolly.m_PathPosition = Mathf.Clamp(dolly.m_PathPosition - camSpeed * Time.deltaTime, 0 ,dolly.m_Path.PathLength);
        }

    }
}

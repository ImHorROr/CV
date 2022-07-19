using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class U10PS_DissolveOverTime : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private RawImage image;

    bool desolved = false;

    private void Start(){
        meshRenderer = this.GetComponent<MeshRenderer>();
        image = this.GetComponent<RawImage>();
    }

    public float speed = .5f;
    private float t = 0.0f;
    private void Update(){
        Desolve();
    }

    public void Desolve()
    {
        if (desolved == true) return;
        Material[] mats = meshRenderer.materials;

        mats[0].SetFloat("_Cutoff", Mathf.Sin(t * speed));
        t += Time.deltaTime;
        meshRenderer.materials = mats;
        if(mats[0].GetFloat("_Cutoff") == 1)
        {
            desolved = true;
        }
    }
    public void Revolve()
    {
        if (desolved == false) return;
        Material[] mats = meshRenderer.materials;

        mats[0].SetFloat("_Cutoff", Mathf.Sin(t * speed));
        t += Time.deltaTime;
        meshRenderer.materials = mats;
        if (mats[0].GetFloat("_Cutoff") == 0)
        {
            desolved = false;
        }

    }

}

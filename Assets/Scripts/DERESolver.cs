using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DERESolver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]Material material;
    public float speed = .5f;
    private float t = 0.0f;
    [SerializeField]  bool desolved = false;
    [SerializeField ]bool startResolve = false;

    void Start()
    {
    }
    private void OnDisable()
    {
        material.SetFloat("_Cutoff", 1);
        
    }
    private void OnEnable()
    {
        material.SetFloat("_Cutoff", 0);
    }
    private void OnMouseOver()
    {
        StartCoroutine(Desolve());
    }
    private void OnMouseEnter()
    {
        startResolve = false;

    }
    private void OnMouseExit()
    {
        startResolve = true;
        StopCoroutine(Desolve());

    }

    IEnumerator Desolve()
    {
        if (desolved == true || startResolve == true) yield break;
        material.SetFloat("_Cutoff", Mathf.Lerp(0, 1, t * speed));
        t += Time.deltaTime;
        if (material.GetFloat("_Cutoff") >= 1)
        {
            desolved = true;
            t = 0;
            yield break;
        }
    }
    void Resolve()
    {
        t += Time.deltaTime;
        material.SetFloat("_Cutoff", Mathf.SmoothDamp(material.GetFloat("_Cutoff"),0,ref t, speed));
        if (material.GetFloat("_Cutoff") <= 0)
        {
            desolved = false;
            startResolve = false;
            t = 0;

        }

    }
    // Update is called once per frame
    void Update()
    {
        if(startResolve == true)
        {

            Resolve();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class testvr : MonoBehaviour
{
    Follower follower;
    float gazetimer;
    float ActivateEvent = 1f;
    [SerializeField] Image indecatorForTimer;
    [SerializeField] Button click;
    bool gazeStatus;
    bool done;
    public void OnPointerEnter()
    {
        gazeStatus = true;
        print(gameObject + "enter");

    }
    public void OnPointerClick()
    {
        print(gameObject + "click");
        
    }
    public void OnPointerExit()
    {
        gazeStatus = false;
        gazetimer = 0;
        indecatorForTimer.fillAmount = 0;
        print(gameObject + "exit");

    }
    public void Update()
    {
        if(gazeStatus)
        {
            gazetimer += Time.deltaTime;
            indecatorForTimer.fillAmount = gazetimer / ActivateEvent;
        }
        if(gazetimer > ActivateEvent)
        {
            click.onClick.Invoke();
            gazetimer = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        follower = FindObjectOfType<Follower>();
    }

    // Update is called once per frame
}

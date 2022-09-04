using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class killable : MonoBehaviour
{
    float gazetimer;
    float ActivateEvent = 2f;
    [SerializeField] Image indecatorForTimer;
    bool gazeStatus;
    bool killableNow;
    public float health = 10;
    Animator animator;
    [SerializeField]ParticleSystem particleSystem;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OnPointerEnter()
    {
        gazeStatus = true;
        print(gameObject + "enter");

    }
    public void OnPointerClick()
    {
        if(!killableNow )
        {
            StartCoroutine(changeColor());
            return;
        }
        else
        {
            health -= 5;
            animator.SetTrigger("hit");
            particleSystem.Play();
            killableNow = false;
            gazetimer = 0;
            indecatorForTimer.fillAmount = 0;
            if (health <= 0)
            {
                animator.ResetTrigger("hit");
                animator.SetBool("attack", false);
                animator.SetBool("walk", false);
                animator.SetTrigger("die");
                Invoke("disableChar", 5f);

            }
        }
    }
    void disableChar()
    {
        gameObject.SetActive(false);

    }
    public void OnPointerExit()
    {
        gazeStatus = false;
        gazetimer = 0;
        indecatorForTimer.fillAmount = 0;

    }
    IEnumerator changeColor()
    {
        indecatorForTimer.color = Color.red;
        yield return new WaitForSeconds(1);
        indecatorForTimer.color = Color.white;

    }
    public void Update()
    {
        if (gazeStatus)
        {
            gazetimer += Time.deltaTime;
            if (indecatorForTimer.fillAmount == 1)
            {
                killableNow = true;
                return;

            }
            indecatorForTimer.fillAmount = gazetimer / ActivateEvent;
        }
        if (gazetimer > ActivateEvent)
        {
            gazetimer = 0;
        }
    }

}

using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MatchBehaviour : MonoBehaviour
{
    [SerializeField][TagSelector]string tag_box_match;
    [SerializeField] UnityEvent FIRE_ON;
    [SerializeField] UnityEvent FIRE_OFF;
    [SerializeField]GameObject fire;
    [SerializeField]Rigidbody match_rb;
    [SerializeField]Collider match_head_col;
    [SerializeField] float fire_duration = 20;

    public bool is_touching = false;
    public bool can_burn = false;
    public bool in_fire = false;
    Coroutine burn_coroutine;

    private void Start() {
        StartCoroutine(EnableHead());
    }

    IEnumerator EnableHead()
    {
        yield return new WaitForSeconds(1);
        match_head_col.enabled = true;
    }

    private void OnCollisionEnter(Collision other) {

        Collider contact = other.GetContact(0).otherCollider;
        
        if(contact.transform.tag == tag_box_match)
        {
            is_touching = true;
            if(burn_coroutine != null)
            {
                StopCoroutine(burn_coroutine);
            }
            burn_coroutine = StartCoroutine(EnableBurning());
        }
    }

    IEnumerator EnableBurning()
    {
        yield return new WaitForSeconds(.1f);
        can_burn = true;
    }

    private void OnCollisionExit(Collision other) {
        if(other.transform.tag == "BoxParentMatch")
        {
            is_touching = false;
            can_burn = false;
            if(burn_coroutine != null)
            {
                StopCoroutine(burn_coroutine);
            }
        }
    }

    private void Update() {

        if(!in_fire && is_touching && can_burn && match_rb.linearVelocity.magnitude > .5f)
        {
            fire.SetActive(true);
            in_fire = true;
            FIRE_ON?.Invoke();
            StartCoroutine(OffMatch());
        }
    }

    IEnumerator OffMatch()
    {
        yield return new WaitForSeconds(fire_duration);
        FIRE_OFF?.Invoke();
        fire.SetActive(false);
        Destroy(gameObject);
    }
}

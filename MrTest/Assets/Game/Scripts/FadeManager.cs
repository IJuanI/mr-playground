using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public static FadeManager globalFade;
    Animator anim;

    void Start()
    {
        if(globalFade != null)
        {
            Destroy(gameObject);
        }
        else
        {
            globalFade = this;
            anim = GetComponent<Animator>();
        }
    }

    public void FadeIn(float fadeTransition)
    {
        anim.SetFloat("TransitionIn",1/fadeTransition);
        anim.SetTrigger("FadeIn");
    }

    public void FadeOut(float fadeTransition)
    {
        anim.SetFloat("TransitionOut",1/fadeTransition);
        anim.SetTrigger("FadeOut");
    }
}

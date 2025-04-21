using System.Collections.Generic;
using UnityEngine;


public class GhostPatrolAnim : MonoBehaviour
{
    [SerializeField]Animator anim;
    [SerializeField]float transitionSpeed;
    [SerializeField]List<GenericStructTwoParams<string,Vector2>> mapTransition;
    public string currentAnim;
    Dictionary<string,Vector2> dictionaryTransition;

    float blendTreeX;
    float blendTreeY;

    int hashBlendX;
    int hashBlendY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dictionaryTransition = mapTransition.CreateDictionary();
        hashBlendX = Animator.StringToHash("x");
        hashBlendY = Animator.StringToHash("y");

        blendTreeX = anim.GetFloat("x");
        blendTreeY = anim.GetFloat("y");
    }

    void LerpValue(ref float valueAnim,float valueDestiny)
    {
        valueAnim = Mathf.Lerp(valueAnim,valueDestiny,Time.deltaTime*transitionSpeed);
    }

    public void ChangeAnim(string nameTransition)
    {
        if(dictionaryTransition.ContainsKey(nameTransition))
            currentAnim = nameTransition;
    }
    
    void Update()
    {
        LerpValue(ref blendTreeX,dictionaryTransition[currentAnim].x);
        LerpValue(ref blendTreeY,dictionaryTransition[currentAnim].y);

        anim.SetFloat(hashBlendX,blendTreeX);
        anim.SetFloat(hashBlendY,blendTreeY);
    }
}

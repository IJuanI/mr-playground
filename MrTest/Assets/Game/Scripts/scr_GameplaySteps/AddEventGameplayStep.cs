using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class AddEventGameplayStep : MonoBehaviour
{
    [SerializeField]float waitSecondsForCreators;
    [SerializeField]List<MethodsForEvents> methodsList;

    private void Start() {
        StartCoroutine(WaitForCreators());
    }

    IEnumerator WaitForCreators()
    {
        yield return new WaitForSeconds(waitSecondsForCreators);
        AssignMethodsToRandomSteps();
    }

    void AssignMethodsToRandomSteps()
    {
        for(int i = 0; i < methodsList.Count;i++)
        {
            //int index = UnityEngine.Random.Range(0, AllRefGameplayStepes.Instance.gameplaySteps.Count);
            GameplayStep specificStep = AllRefGameplayStepes.Instance.gameplaySteps.Find(gps => gps.stepType == GamePlayStepType.ironSafe);
            var method = methodsList[i];
            specificStep.START_EVENT.AddListener(method.MethodForStart);
           // methodsList[i].gameObject.SetActive(false);
           // AllRefGameplayStepes.Instance.gameplaySteps.RemoveAt(index);    
        }
    }
}

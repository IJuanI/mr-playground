using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class AllRefGameplayStepes : MonoBehaviour
{
    [SerializeField]float waitSecondsForCreators;
    public static AllRefGameplayStepes Instance;
    [HideInInspector]
    public List<GameplayStep> gameplaySteps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        StartCoroutine(WaitForCreators());
    }

    IEnumerator WaitForCreators()
    {
        yield return new WaitForSeconds(waitSecondsForCreators);
        gameplaySteps = FindObjectsByType<GameplayStep>(FindObjectsSortMode.None).ToList();
    }

}

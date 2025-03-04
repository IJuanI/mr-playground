using UnityEngine;
using Unity.AI.Navigation;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
public class NavmeshDestiny : MonoBehaviour
{
    List<GameObject> destiny = new();
    NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SetVars());
    }

    IEnumerator SetVars()
    {
        yield return new WaitForSeconds(.2f);
        destiny = new List<GameObject>(GameObject.FindGameObjectsWithTag("Destiny"));
        agent = GetComponent<NavMeshAgent>();
        AssignPos();
    }

    private void Update() {
        if(Vector3.Distance(agent.transform.position,agent.destination) < .5f)
        {
            AssignPos();
        }
    }

    void  AssignPos()
    {
        int index = Random.Range(0, destiny.Count-1);
        agent.SetDestination(destiny[index].transform.position);
    }


}

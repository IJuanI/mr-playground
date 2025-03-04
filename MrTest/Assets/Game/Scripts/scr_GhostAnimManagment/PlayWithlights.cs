using System.Collections;
using UnityEngine;

public class PlayWithlights : MonoBehaviour
{
    InteractiveSwitch interactiveSwitch ;
    public float randomPlayMinTime = 0;
    public float randomPlayMaxTime;
    public float waitForCreators;    	

    private void Start() {
        StartCoroutine(RandomlyOff());
    }

    public IEnumerator RandomlyOff()
    {
        yield return new WaitForSeconds(waitForCreators);
        interactiveSwitch = InteractiveSwitch.InstanceLight;
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(randomPlayMinTime,randomPlayMaxTime));
            if(interactiveSwitch.current_state)
            {
                interactiveSwitch.ChangeState();
            }
        }
    }


}

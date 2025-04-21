using UnityEngine;
using UnityEngine.Events;

public enum GamePlayStepType{ironSafe,Clock,Diary,MusicBox,BurnPaper,TrapDoor};
public abstract class GameplayStep : MonoBehaviour
{
    public GamePlayStepType stepType;
    public UnityEvent START_EVENT = new UnityEvent();
    public UnityEvent END_EVENT = new UnityEvent();
    public void StartEventGameplay()
    {
        START_EVENT?.Invoke();
    }

    public void EndEventGameplay()
    {
        END_EVENT?.Invoke();
    }
    
}

using System.Collections.Generic;
using UnityEngine;


public enum StatePatrol{Idle,Looking,Walk,Run,DetectPlayer,JumpScare}

public class PatrolGhost : MethodsForEvents
{
    [SerializeField]GhostPatrolAnim ghostAnim;
    public List<GenericStructTwoParams<StatePatrol,BaseBehaviour>> stateMachineList;
    Dictionary<StatePatrol,BaseBehaviour> stateMachineMap;
    [SerializeField]StatePatrol currentState = StatePatrol.Idle;
    void Start()
    {
        stateMachineMap = stateMachineList.CreateDictionary();
        InitStepStateMachine();
    }

    //Comienza fantasma en trance
    //al cabo de un tiempo aleatorio pasa a estado de buscar presa.
    //luego de buscar presa si no logra encontrarla a la vista en un radio o tal vez en un cono de una determinada distancia.
    //si no lo encuentra pasa a caminar a alguno de los siguientes puntos.
    //si lo encuentra pasa a correr al jugador.
   

   void InitStepStateMachine()
   {
        stateMachineMap[currentState].FINISH_BY_TIME.RemoveListener(ChangeStateByTime);
        stateMachineMap[currentState].FINISH_BY_BEHAIVIOUR.RemoveListener(ChangeStateByBehaviour);

        if (stateMachineMap == null)return;
        stateMachineMap[currentState].FINISH_BY_TIME.AddListener(ChangeStateByTime);
        stateMachineMap[currentState].FINISH_BY_BEHAIVIOUR.AddListener(ChangeStateByBehaviour);
        stateMachineMap[currentState].InitBehaviour();
        ghostAnim.ChangeAnim(currentState.ToString());
   }

   void ChangeStateByTime()
   {
        stateMachineMap[currentState].enabled = false;
        switch(currentState)
        {
            case StatePatrol.Idle:
                currentState = StatePatrol.Looking;
            break;
            case StatePatrol.Looking:
                currentState = StatePatrol.Walk;
            break;
            case StatePatrol.Walk:
                currentState = StatePatrol.Looking;
            break;
            case StatePatrol.DetectPlayer:
                currentState = StatePatrol.Idle;
            break;
        }
        if(stateMachineMap.ContainsKey(currentState))
        {
            stateMachineMap[currentState].enabled = true;
            InitStepStateMachine();
        }
   }

   void ChangeStateByBehaviour()
   {
        stateMachineMap[currentState].enabled = false; ;
        switch(currentState)
        {
            case StatePatrol.Looking:
                currentState = StatePatrol.Run;
            break;
            case StatePatrol.Run:
                currentState = StatePatrol.DetectPlayer;
            break;
            case StatePatrol.DetectPlayer:
                currentState = StatePatrol.JumpScare;
            break;
        }
        if(stateMachineMap.ContainsKey(currentState))
        {
            stateMachineMap[currentState].enabled = true;
            InitStepStateMachine();
        }
   }

    public override void MethodForStart()
    {
        START_METHOD_EVENT?.Invoke();
    }

}
using UnityEngine;

public class RitualManagment : MonoBehaviour
{
    [SerializeField]ScriptableRitualRequisit stepsRitual;
    public bool initRitual = false;
    int currentIndexStep = 0;
    RitualStep currentStep;

    private void Update() {
        if(initRitual)
        {
            StartRitual();
            initRitual = false;
        }
    }

    public void StartRitual()
    {
        if (stepsRitual == null || !initRitual)return;
        SetStep();
        //debo recorrer los pasos del ritual y ejecutarlos uno a uno,
        // a medida que se llama al metodo de finalizacion del paso del ritual,
        // se debe llamar al siguiente paso y repetir.
    }

    void SetStep()
    {
        Debug.Log("STARTING RITUAL");
        if(currentIndexStep >= stepsRitual.steps.Count)
        {
            FinishRitual();
            return;
        } 

        if(currentStep) currentStep.StopStep();
        currentStep = stepsRitual.steps[currentIndexStep];
        currentStep.FINISH_STEP.AddListener(SetStep);
        currentStep.InitStep();
        currentIndexStep++;
    }

    void FinishRitual()
    {
        Debug.Log("FINISH RITUAL");
    }
}

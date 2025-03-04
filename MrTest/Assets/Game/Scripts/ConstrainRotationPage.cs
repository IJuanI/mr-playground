using Oculus.Interaction;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class ConstrainRotationPage : MonoBehaviour
{
    public ConstrainRotationPage prev_pag;
    public ConstrainRotationPage next_pag;
    [SerializeField] float min_treshold_angle;
    [SerializeField] float pag_treshold_angle;
    [SerializeField] OneGrabRotateTransformer rotator;
    [SerializeField] Collider col;
    public bool limited_pag = false;
    public bool log = false;
    public TMP_Text txt;

    // Update is called once per frame
    void Update()
    {
        /*
        if(!col.enabled && math.abs(prev_pag.localEulerAngles.z - transform.localEulerAngles.z) > 60)
        {
            col.enabled = true;
        }
        else
        {
            col.enabled = false;
        }*/


        if(prev_pag)
        {
            rotator.Constraints.MaxAngle.Value = prev_pag.transform.localEulerAngles.z - 1;
            if( math.abs(prev_pag.transform.localEulerAngles.z - transform.localEulerAngles.z) > pag_treshold_angle)
            {
                col.enabled = true;
            }
            else
            {
                if(!prev_pag.limited_pag)
                    col.enabled = false;
            }
        }

        if(next_pag)
        {
            rotator.Constraints.MinAngle.Value = next_pag.transform.localEulerAngles.z -1 > rotator.Constraints.MaxAngle.Value ? 0 : next_pag.transform.localEulerAngles.z + 1;
            //pag its min constraint
            //if its in the treshold to the min, and the next is in the treshold angle
            //disable collider 
            if(log)
            {
                Debug.Log(math.abs(transform.localEulerAngles.z - rotator.Constraints.MinAngle.Value - 360) < min_treshold_angle &&
                math.abs(next_pag.transform.localEulerAngles.z - transform.localEulerAngles.z) < pag_treshold_angle);
            }

            limited_pag = math.abs(transform.localEulerAngles.z - rotator.Constraints.MaxAngle.Value) < min_treshold_angle;

            if(limited_pag &&
                math.abs(next_pag.transform.localEulerAngles.z - transform.localEulerAngles.z) < pag_treshold_angle)
            {
                col.enabled = false;
            }
            else
            {
                col.enabled = true;
            }
        }

        if(log)
            txt.text = "MIN IS :"+rotator.Constraints.MinAngle.Value + "\n AND MAX IS :" + rotator.Constraints.MaxAngle.Value;
    }
}

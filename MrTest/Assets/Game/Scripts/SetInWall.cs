using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class SetInWall : MonoBehaviour
{
    [SerializeField]float offset_y;
    [SerializeField]UnityEvent LOCK_IT;
    RaycastHit hit;
    bool seted = false;
    private void Start() 
    {
        StartCoroutine(SetPos());
    }

    IEnumerator SetPos()
    {
        yield return new WaitForSeconds(1);
        SetYPos();
        while(!seted)
        {
            yield return new WaitForSeconds(.1f);
            if( Physics.Raycast(transform.position,transform.right,out hit,1000))
            {
                if(hit.transform.name == "WALL_FACE_EffectMesh")
                {
                    transform.position = hit.point;
                    transform.eulerAngles = new Vector3(0,90+hit.transform.eulerAngles.y,0);
                    seted = true;
                    LOCK_IT?.Invoke();
                }
                else
                {
                    transform.Rotate(0,5,0); 
                }
            }
            else
            {
                transform.Rotate(0,5,0); 
            }
        }
    }

    void SetYPos()
    {
        Transform cam_pos = Camera.main.transform;
        Vector3 my_pos = transform.position;
        my_pos.y = cam_pos.position.y+offset_y;
        transform.position = my_pos;
    }

}

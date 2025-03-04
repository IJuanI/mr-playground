using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class AppearInDistance : MonoBehaviour
{   
    List<GameObject> destiny_points = new();
    Camera cam;

    void OnEnable()
    {
        if(destiny_points.Count == 0)
        {
            SearchPoints();
        }
        OrderPoints();
        Appear();
    }

    void SearchPoints()
    {
        destiny_points = new List<GameObject>( GameObject.FindGameObjectsWithTag("Destiny"));
        cam = Camera.main;
    }
    void OrderPoints()
    {
        destiny_points = destiny_points.OrderBy(point => Vector3.Distance(point.transform.position,cam.transform.position)).ToList();
    }
    public void Appear()
    {
        OrderPoints();
        transform.position = destiny_points[^1].transform.position;//^ implica que se accede desde el final de la lista
        Vector3 previousRot = transform.eulerAngles;
        transform.LookAt(cam.transform.position);
        transform.eulerAngles = new Vector3(previousRot.x,transform.eulerAngles.y+180,previousRot.z);
    }

}

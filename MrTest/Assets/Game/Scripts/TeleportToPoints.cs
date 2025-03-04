using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeleportToPoints : MonoBehaviour
{
    [SerializeField]AudioClip clip;
    AudioSource radio_source;
    [SerializeField]float min_delay;
    [SerializeField]float max_delay;
    [SerializeField]float teleport_treshold;
    List<GameObject> destiny_points = new();
    Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        destiny_points = new List<GameObject>( GameObject.FindGameObjectsWithTag("Destiny"));
        cam = Camera.main;
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        while(true)
        {
            yield return new WaitUntil(()=> Vector3.Distance(cam.transform.position,transform.position) < teleport_treshold);
            yield return new WaitForSeconds(UnityEngine.Random.Range(min_delay,max_delay));
            OrderPoints();

            transform.position = destiny_points[Random.Range(destiny_points.Count/2,destiny_points.Count)].transform.position;
            yield return new WaitForSeconds(.5f);
            if(!radio_source)
            {
                radio_source = GameObject.FindWithTag("Radio").GetComponent<AudioSource>();
            }
            radio_source.PlayOneShot(clip);
            
        }
    }

    void OrderPoints()
    {
        destiny_points = destiny_points.OrderBy(point => Vector3.Distance(point.transform.position,cam.transform.position)).ToList();
    }
}

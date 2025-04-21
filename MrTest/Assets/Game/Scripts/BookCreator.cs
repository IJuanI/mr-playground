using UnityEngine;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public struct CustomPag{
    public GameObject pag;
    public int index_pag;
}
public class BookCreator : MonoBehaviour
{
    [SerializeField] ConstrainRotationPage cover_book;
    [SerializeField] Vector3 offset_create_pos;
    [SerializeField] GameObject pag;
    [SerializeField] float separation_height;
    [SerializeField] float separation_right;
    [SerializeField] List<TextAsset> pags_texts; 
    [SerializeField] List<CustomPag> custom_pags;
    List<ConstrainRotationPage> list_constrains = new();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateTextPags();
        CreateCustomPags();
        AssignConstrains();
        OrderPags();
        cover_book.next_pag = list_constrains[0];
    }

    void CreateTextPags()
    {
        for (int i = 0; i < pags_texts.Count;i++)
        {
            //instantiate in this position and move lower and righter in each iteration, this fix the overlaping pages.
            GameObject created_pag = Instantiate(pag,transform.position,Quaternion.identity,transform);
            created_pag.transform.localRotation =  Quaternion.Euler(0,0,0);

            //Add constrains.
            list_constrains.Add(created_pag.GetComponent<ConstrainRotationPage>());
            

            //set text into the pages.
            string[] separate_pags = pags_texts[i].text.Split('/');
            TMP_Text[] pag_sides = created_pag.GetComponentsInChildren<TMP_Text>();

            if(pag_sides[0] != null)
            {
                pag_sides[0].text = pag_sides[0].tag == "LeftPag"?separate_pags[0] : separate_pags[1];
                pag_sides[1].text = pag_sides[0].tag == "LeftPag"?separate_pags[1] : separate_pags[0];
            }

        }
    }

    void CreateCustomPags()
    {
        for(int i=0;i< custom_pags.Count;i++)
        {
            GameObject created_pag = Instantiate(custom_pags[i].pag,transform.position,Quaternion.identity,transform);
            created_pag.transform.localRotation =  Quaternion.Euler(0,0,0);
            //Add constrains.
            list_constrains.Insert(custom_pags[i].index_pag,created_pag.GetComponent<ConstrainRotationPage>());
        }
    }

    void OrderPags()
    {
        for(int i= 0;i< list_constrains.Count;i++)
        {
            list_constrains[i].transform.position = transform.position + offset_create_pos + (new Vector3(separation_right,separation_height,0) * i);
        }
    }

    void AssignConstrains()
    {
        for(int i = 0;i < list_constrains.Count; i++)
        {
            list_constrains[i].prev_pag = i == 0? cover_book : list_constrains[i-1]; 
            if(i != list_constrains.Count-1)
            {
                list_constrains[i].next_pag = list_constrains[i+1]; 
            }
        }
    }


}

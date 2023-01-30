using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dragmain : MonoBehaviour
{
    public static dragmain OBJ_dragmain;
    public GameObject[] GA_Questions;
    public int I_Qcount;
    public AudioSource AS_crt, AS_wrg;
    public GameObject G_final;

   
    public void Start()
    {
        OBJ_dragmain = this;
        I_Qcount = 0;
        G_final.SetActive(false);
        
        showquestion();
    }
    public void showquestion()
    {
        for (int i = 0; i < GA_Questions.Length; i++)
        {
            GA_Questions[i].SetActive(false);
        }
        GA_Questions[I_Qcount].SetActive(true);
        GA_Questions[I_Qcount].GetComponent<Animator>().enabled = false;

    }
    public void increasecount()
    {
        if (I_Qcount < GA_Questions.Length - 1)
        {
            I_Qcount++;
            showquestion();
        }
        else
        {
            G_final.SetActive(true);
        }
    }
    public void BUT_next()
    {
        GA_Questions[I_Qcount].GetComponent<Animator>().enabled = true;
        Invoke("increasecount", 1.5f);

    }
    public void THI_correct()
    {
        AS_crt.Play();
       
    }
    public void THI_wrg()
    {
        AS_wrg.Play();
    }
    
   
   

    
}

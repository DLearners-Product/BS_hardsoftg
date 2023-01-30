using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextfunc : MonoBehaviour
{
    public GameObject[] GA_objects;
    public int I_Qcount;
    public GameObject G_final;

    public AudioSource AS_Empty;
    public AudioClip[] AC_Clips;
    void Start()
    {
        G_final.SetActive(false);
        I_Qcount = 0;
        THI_ShowQuestion();
    }
    public void THI_ShowQuestion()
    {
        for(int i=0;i<GA_objects.Length;i++)
        {
            GA_objects[i].SetActive(false);
        }
        GA_objects[I_Qcount].SetActive(true);
    }

    public void BUT_Speaker()
    {
        AS_Empty.clip = AC_Clips[I_Qcount];
        AS_Empty.Play();
    }

    public void BUT_Next()
    {
        AS_Empty.Stop();
        if (I_Qcount<GA_objects.Length-1)
        {
            I_Qcount++;
            THI_ShowQuestion();
        }
        else
        {
            G_final.SetActive(true);
        }
    }
    public void BUT_Back()
    {
        AS_Empty.Stop();
        if (I_Qcount > 0)
        {
            I_Qcount--;
            THI_ShowQuestion();
        }
        else
        {
            G_final.SetActive(true);
        }
    }
}

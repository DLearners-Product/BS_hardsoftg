using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audionext : MonoBehaviour
{

    public AudioSource AS_Empty;
    public AudioClip[] AC_Clips;
    public int I_Count;
    public GameObject G_Final;
    // Start is called before the first frame update
    void Start()
    {
        G_Final.SetActive(false);
        I_Count = 0;
    }

    public void BUT_Speaker()
    {
        AS_Empty.clip = AC_Clips[I_Count];
        AS_Empty.Play();
    }

    public void BUT_Next()
    {
        if(I_Count<AC_Clips.Length-1)
        {
            I_Count++;

        }
        else
        {
            G_Final.SetActive(true);
        }
    }

    public void BUT_Back()
    {
        if (I_Count > 0)
        {
            I_Count--;

        }
        else
        {
            G_Final.SetActive(true);
        }
    }
}

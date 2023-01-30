using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clapsnap : MonoBehaviour
{
    public int I_Qcount;
    public AudioSource AS_Crt, AS_Wrg, AS_Empty;
    public AudioClip[] AC_Clips;
    public GameObject G_final;
    public GameObject G_Clap, G_Snap;
    void Start()
    {
        Offeffect();
        G_final.SetActive(false);
        I_Qcount = 0;
    }
    public void BUT_Speaker()
    {
        AS_Empty.clip = AC_Clips[I_Qcount];
        AS_Empty.Play();
    }

    public void BUT_Next()
    {
        if (I_Qcount < AC_Clips.Length - 1)
        {
            I_Qcount++;
        }
        else
        {
            G_final.SetActive(true);
        }
    }

    public void BUT_Back()
    {
        if (I_Qcount > 0)
        {
            I_Qcount--;
        }
        else
        {
            G_final.SetActive(true);
        }
    }
    public void Offeffect()
    {
        G_Clap.SetActive(false);
        G_Snap.SetActive(false);
    }
    public void BUT_Clap()
    {
        if (I_Qcount == 1 || I_Qcount == 2 || I_Qcount == 3 || I_Qcount == 5 || I_Qcount == 11 || I_Qcount == 12)
        {
            G_Clap.SetActive(true);
            Invoke("Offeffect", 2f);
            AS_Crt.Play();
        }
        else
        {
            AS_Wrg.Play();
        }
    }
    public void BUT_Snap()
    {
        if (I_Qcount == 0 || I_Qcount == 4 || I_Qcount == 6 || I_Qcount == 7 || I_Qcount == 8 || I_Qcount == 9 || I_Qcount == 10 || I_Qcount == 13)
        {
            G_Snap.SetActive(true);
            Invoke("Offeffect", 2f);
            AS_Crt.Play();
        }
        else
        {
            AS_Wrg.Play();
        }
    }
}

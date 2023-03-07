using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clapsnap : MonoBehaviour
{
    public int I_Qcount;
    public AudioSource AS_Crt, AS_Wrg, AS_Empty;
    public AudioClip[] AC_Clips;
    public GameObject G_final;
    public GameObject G_Clap, G_Snap;
    // [SerializeField] GameActivityData[] GAA_activityData;
    [SerializeField] Text T_questionCount;
    string activityData;


    void Start()
    {
        Offeffect();
        G_final.SetActive(false);
        I_Qcount = 0;

        ScoreManager.instance.InstantiateScore(AC_Clips.Length);
        // GAA_activityData = new GameActivityData[AC_Clips.Length];
        ScoreManager.instance.THI_InitialiseGameActivity(I_Qcount);

        T_questionCount.text = (I_Qcount + 1).ToString()+" / "+AC_Clips.Length.ToString();
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

            ScoreManager.instance.THI_InitialiseGameActivity(I_Qcount);

            T_questionCount.text = (I_Qcount + 1).ToString()+" / "+AC_Clips.Length.ToString();
        }
        else
        {
            Main_Blended.OBJ_main_blended.STRA_ScoreVal[Main_Blended.OBJ_main_blended.levelno] = ScoreManager.instance.GetActivityData();
            G_final.SetActive(true);
        }
    }

    public void BUT_Back()
    {
        if (I_Qcount > 0)
        {
            I_Qcount--;

            ScoreManager.instance.THI_InitialiseGameActivity(I_Qcount);

            T_questionCount.text = (I_Qcount + 1).ToString()+" / "+AC_Clips.Length.ToString();
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
        // GAA_activityData[I_Qcount].tries++;
        if (I_Qcount == 1 || I_Qcount == 2 || I_Qcount == 3 || I_Qcount == 5 || I_Qcount == 11 || I_Qcount == 12)
        {
            ScoreManager.instance.RightAnswer(I_Qcount);
            // GAA_activityData[I_Qcount].score++;
            G_Clap.SetActive(true);
            Invoke("Offeffect", 2f);
            AS_Crt.Play();
        }
        else
        {
            ScoreManager.instance.WrongAnswer(I_Qcount);
            // GAA_activityData[I_Qcount].failures++;
            AS_Wrg.Play();
        }
    }

    public void BUT_Snap()
    {
        // GAA_activityData[I_Qcount].tries++;
        if (I_Qcount == 0 || I_Qcount == 4 || I_Qcount == 6 || I_Qcount == 7 || I_Qcount == 8 || I_Qcount == 9 || I_Qcount == 10 || I_Qcount == 13)
        {
            ScoreManager.instance.RightAnswer(I_Qcount);
            // GAA_activityData[I_Qcount].score++;
            G_Snap.SetActive(true);
            Invoke("Offeffect", 2f);
            AS_Crt.Play();
        }
        else
        {
            ScoreManager.instance.WrongAnswer(I_Qcount);
            // GAA_activityData[I_Qcount].failures++;
            AS_Wrg.Play();
        }
    }
}

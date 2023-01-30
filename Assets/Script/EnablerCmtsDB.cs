using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class EnablerCmtsDB
{
    public string welcome;
    public string brain_gym_1;
    public string rhyme;
    public string activity_lb;
    public string activity_pws;
    public string brain_gym_2;
    public string activity_writing;
    public string activity_respective_group;
    public string goodbye;


    public EnablerCmtsDB()
    {
        welcome = Main_Blended.OBJ_main_blended.enablerComments[0];
        brain_gym_1 = Main_Blended.OBJ_main_blended.enablerComments[1];
        rhyme = Main_Blended.OBJ_main_blended.enablerComments[2];
        activity_lb = Main_Blended.OBJ_main_blended.enablerComments[3];
        activity_pws = Main_Blended.OBJ_main_blended.enablerComments[4];
        brain_gym_2 = Main_Blended.OBJ_main_blended.enablerComments[5];
        activity_writing = Main_Blended.OBJ_main_blended.enablerComments[6];
        activity_respective_group = Main_Blended.OBJ_main_blended.enablerComments[7];
        goodbye = Main_Blended.OBJ_main_blended.enablerComments[8];
    }
}
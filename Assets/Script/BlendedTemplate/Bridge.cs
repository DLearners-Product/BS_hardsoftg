﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

public class Bridge : MonoBehaviour
{

#if UNITY_WEBGL && !UNITY_EDITOR

    [DllImport("__Internal")]
    static extern void CallSyllabyfyText(string syllabifytext);
    
    [DllImport("__Internal")]
    private static extern void TeacherInst(string htmlJson);
    
    [DllImport("__Internal")]
    private static extern void Game(string name);

    [DllImport("__Internal")]
    private static extern void SetBlendedData(string value);

    [DllImport("__Internal")]
    private static extern void PassActivityScoreData(string value);
#endif

    string[] slide_name;
    string[] slideInst;

    bool[] videoSlides;
    bool[] worksheetSlides;
    bool[] syllableSlides;
    bool[] grammerSlides;

    Html_values html_Values;

    string gameName;

    void Start()
    {

#if !UNITY_EDITOR && UNITY_WEBGL
        WebGLInput.captureAllKeyboardInput = true;
#endif
        slide_name = new string[Main_Blended.OBJ_main_blended.MAX_SLIDES];
        slideInst = new string[Main_Blended.OBJ_main_blended.MAX_SLIDES];
        videoSlides = new bool[Main_Blended.OBJ_main_blended.MAX_SLIDES];
        worksheetSlides = new bool[Main_Blended.OBJ_main_blended.MAX_SLIDES];
        syllableSlides = new bool[Main_Blended.OBJ_main_blended.MAX_SLIDES];
        grammerSlides = new bool[Main_Blended.OBJ_main_blended.MAX_SLIDES];

        slide_name = Main_Blended.OBJ_main_blended.SLIDE_NAMES;
        slideInst = Main_Blended.OBJ_main_blended.TEACHER_INSTRUCTION;
        videoSlides = Main_Blended.OBJ_main_blended.HAS_VIDEO;
        worksheetSlides = Main_Blended.OBJ_main_blended.HAS_WORKSHEET;
        syllableSlides = Main_Blended.OBJ_main_blended.HAS_SYLLABLE;
        grammerSlides = Main_Blended.OBJ_main_blended.HAS_GRAMMER;

        GetTeacherInst();
        getGameName();
    }

    public void GetTeacherInst()
    {
        html_Values = new Html_values(slide_name, slideInst, videoSlides, worksheetSlides, syllableSlides, grammerSlides);

        string htmlJson = JsonConvert.SerializeObject(html_Values);
        string xValue = JsonConvert.DeserializeObject(htmlJson).ToString();

        Debug.Log(xValue);


#if UNITY_WEBGL && !UNITY_EDITOR
    SetBlendedData(htmlJson);
    TeacherInst(xValue);
#endif

    }    
    public void getGameName()
    {
        gameName = Main_Blended.OBJ_main_blended.GameName;

        Debug.Log(gameName);

#if UNITY_WEBGL && !UNITY_EDITOR
    Game(gameName);
#endif

    }

    public void SyllabyfyText(string dataToSyllabify)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        CallSyllabyfyText(dataToSyllabify);
#endif
    }

    public void SendActivityScoreData(string scoreData){
#if UNITY_WEBGL && !UNITY_EDITOR
        PassActivityScoreData(scoreData);
#endif  
    }
}
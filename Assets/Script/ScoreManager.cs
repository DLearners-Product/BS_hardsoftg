using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    string activityData;
    public static ScoreManager instance;
    [SerializeField] BlendedSlideActivityData[] lessonGameActivityDatas;
    // [SerializeField] GameActivityData[] GAA_activityData;

    private void Awake()
    {
        instance = this;
    }

    public void InitializeLessonActivityData(int arrLength){
        lessonGameActivityDatas = new BlendedSlideActivityData[arrLength];
    }

    public void InstantiateScore(int arrSize){
        Debug.Log($"came to InstantiateScore "+arrSize);
        Debug.Log($"Level No : "+Main_Blended.OBJ_main_blended.levelno);
        lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities = new SlideActivityData[arrSize];
    }

    public void THI_InitialiseGameActivity(int QCount){
        if (lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities[QCount] == null){
            lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities[QCount] = new SlideActivityData(QCount);
        }
    }

    public string GetActivityData(){
        if(lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities != null && lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities.Length > 0){
            return null;
        }

        activityData = "[";

        for(int i=0; i < lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities.Length; i++){
            activityData += lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities[i].getParsedJsonData();
            if((i+1) < lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities.Length){
                activityData += ",";
            }
        }

        activityData = "]";
        return activityData;
    }

    // public string GetAllActivityData(){
    // }

    public void RightAnswer(int questionIndex, int scorevalue = 1){
        lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities[questionIndex].tries++;
        lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities[questionIndex].score += scorevalue;
    }

    public void WrongAnswer(int questionIndex, int scorevalue = 1){
        lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities[questionIndex].tries++;
        lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities[questionIndex].failures += scorevalue;
    }
}

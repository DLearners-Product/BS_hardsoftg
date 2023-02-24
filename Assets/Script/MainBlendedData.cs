using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class MainBlendedData : MonoBehaviour
{
    public SlideData[] slideData;
    List<int> slideDataCounts;
    public static MainBlendedData instance;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    void Start()
    {
        slideDataCounts = new List<int>();
    }

    void Update()
    {
        PopulateData();
    }

    void PopulateData(){
        Debug.Log("Came here");
        Debug.Log((Main_Blended.OBJ_main_blended == null));
        for(int i=0; i<slideData.Length; i++){
            if(slideData[i].slideObject != null){
                // IterPrefabObject(slideData[i].slideObject);
                List<GameObject> textObjects = new List<GameObject>();
                textObjects = GetAllTextComponent(textObjects, slideData[i].slideObject);
                slideData[i].slideName = slideData[i].slideObject.name;
                slideData[i].textComponents = new List<TextComponentData>();
                for(int j=0; j<textObjects.Count; j++){
                    slideData[i].textComponents.Add(new TextComponentData("G_"+j.ToString(), textObjects[j]));
                }
            }
        }
    }

    public void AssignData(int index){
        // for(int i=0; i<slideData.Length; i++){
            slideData[index].textComponents[0].component.GetComponent<Text>().text="Text changed";
        // }
    }

    List<GameObject> GetAllTextComponent(List<GameObject> listObject, GameObject rootObject){
        if(rootObject.GetComponent<Text>() != null){
            listObject.Add(rootObject);
        }
        for(int i=0; i<rootObject.transform.childCount; i++){
            if(rootObject.transform.GetChild(i).gameObject.GetComponent<Text>() != null){
                listObject.Add(rootObject.transform.GetChild(i).gameObject);
            }
        }
        return listObject;
    }

    void IterPrefabObject(GameObject prefab){
        for(int i=0; i<prefab.transform.childCount; i++){
            Debug.Log(prefab.transform.GetChild(i).name);
        }
    }

    private void OnValidate() {
        // for(int i=0; i<slideData.Length; i++){
        //     if(slideData[i].textComponents.Count < slideDataCounts[i]){
        //         for(int j=0; j<slideData[i].textComponents.Count; j++){
        //             slideData[i].textComponents[j].componentID = "B_"+slideData[i].textComponents.Count.ToString();
        //         }
        //     }
        // }
    }
}

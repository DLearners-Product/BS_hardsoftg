using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class MainBlendedData : MonoBehaviour
{
    public List<SlideData> slideData;
    List<int> slideDataCounts;
    public static MainBlendedData instance;
    List<GameObject> textObjects = new List<GameObject>();
    List<SlideData> oldSlideData = new List<SlideData>();
    int currentSlideIndex = 0;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    void Start()
    {
        Debug.Log("Start method called");
        slideDataCounts = new List<int>();
        for(int i=0; i<slideData.Count; i++){
            oldSlideData.Add(slideData[i]);
        }
    }

    void Update()
    {
        UpdateInspector();
    }

    public void UpdateInspector(){
        for(; currentSlideIndex < slideData.Count; currentSlideIndex++){
            bool isNewActivity = ((oldSlideData.Count - 1) < currentSlideIndex && slideData[currentSlideIndex].slideObject != null);
            bool isOldActivityChanged = ((oldSlideData.Count) > currentSlideIndex && oldSlideData[currentSlideIndex].slideObject != slideData[currentSlideIndex].slideObject);

            if(isNewActivity || isOldActivityChanged){
                if(isNewActivity){
                    oldSlideData.Add(slideData[currentSlideIndex]);
                }
                PopulateTextField();
                UpdateOldSlideData();
            }
        }
        currentSlideIndex = 0;
    }

    void PopulateTextField(){
        if(slideData[currentSlideIndex].slideObject != null){
            slideData[currentSlideIndex].textComponents = new List<TextComponentData>();
            
            GetAllTextComponent(slideData[currentSlideIndex].slideObject);
            
            slideData[currentSlideIndex].slideName = slideData[currentSlideIndex].slideObject.name;
        }
    }

    void UpdateOldSlideData(){
        oldSlideData[currentSlideIndex].slideName = slideData[currentSlideIndex].slideName;
        oldSlideData[currentSlideIndex].slideObject = slideData[currentSlideIndex].slideObject;

        oldSlideData[currentSlideIndex].textComponents.Clear();

        for(int i=0; i<slideData[currentSlideIndex].textComponents.Count; i++){
            oldSlideData[currentSlideIndex].textComponents.Add(slideData[currentSlideIndex].textComponents[i]);
        }
    }

    public void AssignData(int index){
        // for(int i=0; i<slideData.Length; i++){
            slideData[index].textComponents[0].component.GetComponent<Text>().text="Text changed";
        // }
    }

    void GetAllTextComponent(GameObject rootObject){
        if(rootObject.GetComponent<Text>() != null){
            slideData[currentSlideIndex].textComponents.Add(
                new TextComponentData("G_"+(slideData[currentSlideIndex].textComponents.Count + 1).ToString(), rootObject)
            );
        }
        if(rootObject.transform.childCount > 0){
            for(int j=0; j<rootObject.transform.childCount; j++){
                GetAllTextComponent(rootObject.transform.GetChild(j).gameObject);
            }
        }
    }

    void IterPrefabObject(GameObject prefab){
        for(int i=0; i<prefab.transform.childCount; i++){
            Debug.Log(prefab.transform.GetChild(i).name);
        }
    }

    private void OnValidate() {}
}

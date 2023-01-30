using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Passage : MonoBehaviour
{
    public GameObject G_Button,G_selected;

    void Start()
    {
        for(int i=0;i<G_Button.transform.childCount;i++)
        {
            G_Button.transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void BUT_Click()
    {
        G_selected = EventSystem.current.currentSelectedGameObject;
        Debug.Log("pressed = "+G_selected.name);
        G_selected.transform.GetChild(0).gameObject.SetActive(true);
    }
}

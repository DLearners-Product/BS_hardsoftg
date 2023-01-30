using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class drag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector2 mousePos;
    public Vector2 initalPos;

    bool isdrag;
    GameObject otherGameObject,dummy;

    Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Start()
    {
        //initalPos = this.GetComponent<RectTransform>().position;
        initalPos = this.transform.position;
    }


    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mousePos;
        StopAllCoroutines();
        Debug.Log("Drag");
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        if(otherGameObject!=null)
        {
            dummy = otherGameObject;
            if (this.gameObject.name == otherGameObject.name)
            {
                // otherGameObject.GetComponent<Image>().enabled = true;
                // otherGameObject.transform.GetChild(0).GetComponent<Text>().text = this.transform.GetChild(0).GetComponent<Text>().text;
                this.gameObject.SetActive(false);
                dummy.transform.GetChild(1).GetComponent<Image>().enabled = true;
                dragmain.OBJ_dragmain.THI_correct();
                this.GetComponent<drag>().enabled = false;
            }
            else
            {
               // dummy = otherGameObject;
                StartCoroutine(wrong());
                dragmain.OBJ_dragmain.THI_wrg();
                this.transform.position = initalPos;
            }
        }else
        {
            this.transform.position = initalPos;
        }
        
    }
    public IEnumerator wrong()
    {
        Debug.Log("wrong");
        for(int i=0;i<3;i++)
        {
            Debug.Log("wrong");
            yield return new WaitForSeconds(0.5f);
            dummy.transform.GetChild(0).GetComponent<Image>().enabled = true;

            yield return new WaitForSeconds(0.5f);
            dummy.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.parent.name == "Drop")
            otherGameObject = other.gameObject;

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.parent.name == "Drop")
            otherGameObject = null;
       

    }

}

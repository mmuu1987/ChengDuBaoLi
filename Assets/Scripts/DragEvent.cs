using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragEvent : MonoBehaviour, IBeginDragHandler, IEndDragHandler,IPointerClickHandler,IDragHandler
{

    public event Action<bool> DragDirEvent;

    private float moveX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("begin drag");
        moveX = eventData.position.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (moveX >= eventData.position.x)
        {
            if (DragDirEvent != null)
            {
                DragDirEvent(true);
            }
            Debug.Log("右移动");
        }
        else
        {
            if (DragDirEvent != null)
            {
                DragDirEvent(false);
            }
            Debug.Log("左移动");
        }
        //Debug.Log("end drag");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       // Debug.Log("click");
    }

    public void OnDrag(PointerEventData eventData)
    {
       // Debug.Log("drag");
    }
}

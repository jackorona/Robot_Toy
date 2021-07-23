using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObj : MonoBehaviour
{
    float ObjPos_Z;
    public bool isSelected;
    Vector3 DistanceOffset;
    [SerializeField] GameObject HighlightObj;

    //=====================================================
    // Get this objects Z position and distance from camera
    //=====================================================
    private void OnMouseDown() 
    {
        ObjPos_Z = Camera.main.WorldToScreenPoint(transform.position).z;
        DistanceOffset = transform.position - MousePosition();
    }


    //=====================================================
    // Move this object to MousePosition
    //=====================================================
    private void OnMouseDrag() 
    {
        transform.position = MousePosition();
    }


    //=====================================================
    // Return position of mouse with "ObjPos_Z" offset on Z
    //=====================================================
    Vector3 MousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = ObjPos_Z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }


    //=====================================================
    // Enables "HighlightObj" if mouse is hovering over
    //=====================================================
    void OnMouseOver()
    {   
        if (Input.GetMouseButtonDown(0)){
            isSelected = true;
            HighlightObj.SetActive(false);
        }

        if (Input.GetMouseButtonUp(0)){
            isSelected = false;
        }

        if (!isSelected){
            HighlightObj.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        HighlightObj.SetActive(false);
    }
}

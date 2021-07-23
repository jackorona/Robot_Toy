using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attachment : MonoBehaviour
{
    [SerializeField]  GameObject PartObj, HighlightModel;
    [SerializeField] Text StatusUI;
    [SerializeField] string PartName;
    bool isAttached, isObjClose;
    
    private void Start() 
    {
        isObjClose = true;
        Attach();
    }

    //=====================================================
    // Detects if "PartObj" is nearby.
    // Enables or disables highlight object.
    //=====================================================
    private void OnTriggerEnter(Collider other)          
    {
        if (other.tag == "Selectable" && !isAttached){
            isObjClose = true;
            HighlightModel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Selectable"){
            isObjClose = false;
            HighlightModel.SetActive(false);
        }
    }

    //=====================================================
    // Attach and Detach part based on mouse input. 
    //=====================================================
    private void Update() 
    {
        if (isObjClose){
            if (Input.GetMouseButtonUp(0))
            {
                Attach();
            }

            else if (PartObj.transform.position != transform.position)
            {
                Detach();
            }
        }
    }

    //=====================================================
    // Updates UI status.
    // Enables or disables highlight Object.
    // Moves "PartObj" to attached position when attached.
    //=====================================================
    void Attach()
    {
        isAttached = true;
        HighlightModel.SetActive(false);
        StatusUI.text = PartName + ": Attached";
        PartObj.transform.position = transform.position;
    }

    void Detach()
    {
        isAttached = false;
        HighlightModel.SetActive(true);
        StatusUI.text = PartName + ": Detached";
    }
}

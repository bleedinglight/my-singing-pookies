using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;

public class PookiePickup : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    //this scripts controls the ability to drag and drop the pookies from the hotbar to the world

    private GameObject cursorObject;
    //private GameObject inWorld;
    private GameObject hotbar;
    public LayerMask pookieLayer;
    bool pookieActive = false;
    public Transform parentAfterDrag;

    void Start()
    {
        cursorObject = GameObject.Find("CursorObject");
        //inWorld = GameObject.Find("InWorld");
        hotbar = GameObject.Find("Hotbar");
    }

    // wtf is an interface?? like what is any of this???
    // fuck knows pal
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        parentAfterDrag = transform.parent;
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        if (pookieActive == false)
        {
            transform.position = Input.mousePosition;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        /*if (this.transform.position.y > 85)   // if transform position = grid cell
        {
            Debug.Log("OnEndDrag pos.y > 85");
            //this.transform.SetParent(inWorld.transform);
            //parentAfterDrag = inWorld.transform;
            
            if (pookieActive == false)
            {
                pookieActive = true;
            }
        }
        else if (this.transform.position.y < 85) // else
        {
            Debug.Log("OnEndDrag pos.y < 85");
            //this.transform.SetParent(hotbar.transform);
            parentAfterDrag = hotbar.transform;
            Debug.Log(transform.parent);
            pookieActive = false;
        }*/

        if (parentAfterDrag != null)
        {
            transform.SetParent(parentAfterDrag);
        }
        //Debug.Log(this.transform.position.y);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        if (pookieActive == true)
        {
            this.transform.SetParent(hotbar.transform);
            pookieActive = false;
        }
    }

    public void CheckForGridSlot()
    {
        Debug.Log("Checking for grid slot");
        if (parentAfterDrag.transform.parent.GetComponent<InventorySlot>() == null)
        {
            this.transform.SetParent(hotbar.transform);
            pookieActive = false;
        }
        else
        {
            pookieActive = true;
        }
    }
}
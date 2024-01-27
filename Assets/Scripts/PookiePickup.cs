using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;

public class PookiePickup : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    //this scripts controls the ability to drag and drop the pookies from the hotbar to the world

    private GameObject cursorObject;
    private GameObject hotbar;
    public LayerMask pookieLayer;
    public Transform parentAfterDrag;
    public PookieData pookieData;

    void Start()
    {
        cursorObject = GameObject.Find("CursorObject");
        hotbar = GameObject.Find("Hotbar");
    }

    // wtf is an interface?? like what is any of this???
    // fuck knows pal
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        /*if (this.transform.position.y > 45)   // if transform position = grid cell
        {
            Debug.Log("OnEndDrag pos.y > 85");
            //this.transform.SetParent(inWorld.transform);
            //parentAfterDrag = inWorld.transform;
            
            if (pookieData.pookieActive == false)
            {
                pookieData.pookieActive = true;
            }
        }
        else if (this.transform.position.y < 45) // else
        {
            Debug.Log("OnEndDrag pos.y < 85");
            //this.transform.SetParent(hotbar.transform);
            parentAfterDrag = hotbar.transform;
            Debug.Log(transform.parent);
            pookieData.pookieActive = false;
        }*/

        if (parentAfterDrag != null)
        {
            if (!parentAfterDrag.GetComponent<InventorySlot>().isOccupied)
            {
                this.transform.SetParent(parentAfterDrag);
                parentAfterDrag.GetComponent<InventorySlot>().isOccupied = true;
            }
            else
            {
                this.transform.SetParent(hotbar.transform);
            }
            //transform.SetParent(parentAfterDrag);
        }
        //Debug.Log(this.transform.position.y);
    }

    public void OnPointerClick(PointerEventData eventData)
    {;
        if (this.transform.parent.GetComponent<InventorySlot>().isOccupied)
        {
            this.transform.parent.GetComponent<InventorySlot>().isOccupied = false;
        }
        this.transform.SetParent(hotbar.transform);
    }

    public void CheckForGridSlot()
    {
        //Debug.Log("Checking for grid slot, parentAfterDrag = " + parentAfterDrag);
        if (parentAfterDrag.GetComponent<InventorySlot>() == null)
        {
            //Debug.Log("Inventory slot == null");
            this.transform.SetParent(hotbar.transform);
            pookieData.pookieActive = false;
        }
        else 
        {
            //Debug.Log("Inventory slot != null");
            pookieData.pookieActive = true;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("entered trigger");
        if (other.CompareTag("Grid"))
        {
            parentAfterDrag = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (parentAfterDrag != gameObject.transform.parent)
        {
            this.transform.SetParent(hotbar.transform);
        }
    }
}
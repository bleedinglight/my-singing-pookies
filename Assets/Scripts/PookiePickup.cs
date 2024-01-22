using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PookiePickup : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{

    //this scripts controls the ability to drag and drop the pookies from the hotbar to the world

    private GameObject cursorObject;

    private GameObject inWorld;

    private GameObject hotbar;

    public LayerMask pookieLayer;

    bool pookieActive = false;

    //wtf is an interface?? like what is any of this???
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {

        if (pookieActive == false)
        {
            transform.position = Input.mousePosition;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (this.transform.position.y > 85)   
        {
            this.transform.SetParent(inWorld.transform);
            if (pookieActive == false)
                {
                    pookieActive = true;
                }
        }

        else if (this.transform.position.y < 85)
        {
            this.transform.SetParent(hotbar.transform);
            pookieActive = false;
        }

        Debug.Log(this.transform.position.y);
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (pookieActive == true)
        {
            this.transform.SetParent(hotbar.transform);
            pookieActive = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        cursorObject = GameObject.Find("CursorObject");
        inWorld = GameObject.Find("InWorld");
        hotbar = GameObject.Find("Hotbar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

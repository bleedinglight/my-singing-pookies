using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public int slotID;
    public bool isOccupied;

    void Update()
    {
        if (transform.childCount > 0)
        {
            isOccupied = true;
        }
        else
        {
            isOccupied = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!isOccupied)
        {
            GameObject dropped = eventData.pointerDrag;
            PookiePickup pookiePickup = dropped.GetComponent<PookiePickup>();
            //PookieData pookieData = dropped.GetComponent<PookieData>();
            pookiePickup.parentAfterDrag = transform;

            pookiePickup.CheckForGridSlot();
        }
    }
}

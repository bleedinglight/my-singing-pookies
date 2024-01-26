using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public int slotID;
    public bool isOccupied;

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
